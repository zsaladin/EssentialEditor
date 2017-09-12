using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace EssentialEditor.Internal
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(MonoBehaviour), true)]
    public class MonoBehaviourInspector : Editor
    {
        Dictionary<MethodInfo, List<object>> _methodParamsDict = new Dictionary<MethodInfo, List<object>>();

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            Type type = target.GetType();

            var exposedProperties = type.GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance).
                Where(item => item.IsDefined(typeof(ExposePropertyAttribute), true)).ToArray();
            if (exposedProperties.Length > 0)
            {
                EditorGUILayout.Separator();
                EditorGUILayout.LabelField("Properties", EditorStyles.boldLabel);
                foreach (PropertyInfo propertyInfo in exposedProperties)
                {
                    if (propertyInfo.IsDefined(typeof(ExposePropertyAttribute), true))
                        DrawProperty(propertyInfo);
                }
            }

            var exposedMethods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance).
                Where(item => item.IsDefined(typeof(ExposeMethodAttribute), true)).ToArray();
            if (exposedMethods.Length > 0)
            {
                EditorGUILayout.Separator();
                EditorGUILayout.LabelField("Methods", EditorStyles.boldLabel);
                foreach (MethodInfo methodInfo in exposedMethods)
                {
                    if (methodInfo.IsDefined(typeof(ExposeMethodAttribute), true))
                        DrawMethod(methodInfo);
                }
            }

            EditorUtility.SetDirty(target);
        }

        void DrawProperty(PropertyInfo propertyInfo)
        {
            try
            {
                if (propertyInfo.GetGetMethod(true) == null)
                    return;

                bool hasSetMethod = propertyInfo.GetSetMethod(true) != null;
                if (hasSetMethod == false)
                    GUI.enabled = false;

                object value = TypeDrawer.Draw(propertyInfo.PropertyType, propertyInfo.Name, propertyInfo.GetValue(target, null));

                if (hasSetMethod)
                    propertyInfo.SetValue(target, value, null);

                GUI.enabled = true;
            }
            catch (Exception ex)
            {
                EditorGUILayout.LabelField(ex.ToString());
            }
        }

        void DrawMethod(MethodInfo methodInfo)
        {
            try
            {
                var impossibleParams = methodInfo.GetParameters().Where(item =>
                item.ParameterType != typeof(int) &&
                item.ParameterType != typeof(float) &&
                item.ParameterType != typeof(string) &&
                item.ParameterType != typeof(bool) &&
                item.ParameterType != typeof(Vector2) &&
                item.ParameterType != typeof(Vector3) &&
                item.ParameterType != typeof(Vector4) &&
                item.ParameterType.IsEnum == false).ToArray();

                if (impossibleParams.Length > 0)
                    return;

                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.PrefixLabel(methodInfo.Name);

                List<object> methodParams = null;
                if (_methodParamsDict.TryGetValue(methodInfo, out methodParams) == false)
                {
                    methodParams = new List<object>();
                    _methodParamsDict.Add(methodInfo, methodParams);
                }

                EditorGUILayout.BeginVertical();

                ParameterInfo[] parameters = methodInfo.GetParameters();
                for (int i = 0; i < parameters.Length; ++i)
                {
                    if (methodParams.Count <= i)
                    {
                        if (parameters[i].ParameterType.IsValueType)
                            methodParams.Add(Activator.CreateInstance(parameters[i].ParameterType));
                        else
                            methodParams.Add(null);
                    }

                    methodParams[i] = TypeDrawer.Draw(parameters[i].ParameterType, parameters[i].Name, methodParams[i]);
                }

                if (GUILayout.Button("Invoke"))
                {
                    object returnValue = methodInfo.Invoke(target, methodParams.ToArray());
                    if (returnValue != null)
                        Debug.Log(returnValue);
                }

                EditorGUILayout.EndVertical();

                EditorGUILayout.EndHorizontal();
            }
            catch (Exception ex)
            {
                EditorGUILayout.LabelField(ex.ToString());
            }
        }
    }
}