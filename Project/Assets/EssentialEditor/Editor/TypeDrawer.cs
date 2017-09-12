﻿using UnityEngine;
using UnityEditor;
using System;

namespace EssentialEditor.Internal
{
    public static class TypeDrawer
    {
        public static object Draw(Type type, string name, object getValue)
        {
            object value = null;
            if (typeof(int) == type)
            {
                value = EditorGUILayout.IntField(name, (int)getValue);
            }
            else if (typeof(long) == type)
            {
                value = EditorGUILayout.LongField(name, (long)getValue);
            }
            else if (typeof(float) == type)
            {
                value = EditorGUILayout.FloatField(name, (float)getValue);
            }
            else if (typeof(string) == type)
            {
                value = EditorGUILayout.TextField(name, (string)getValue);
            }
            else if (typeof(bool) == type)
            {
                value = EditorGUILayout.Toggle(name, (bool)getValue);
            }
            else if (typeof(Vector2) == type)
            {
                value = EditorGUILayout.Vector2Field(name, (Vector2)getValue);
            }
            else if (typeof(Vector3) == type)
            {
                value = EditorGUILayout.Vector3Field(name, (Vector3)getValue);
            }
            else if (typeof(Vector4) == type)
            {
                value = EditorGUILayout.Vector4Field(name, (Vector4)getValue);
            }
            else if (typeof(UnityEngine.Object) == type)
            {
                value = EditorGUILayout.ObjectField(name, (UnityEngine.Object)getValue, typeof(UnityEngine.Object), true);
            }
            else if (type.IsEnum)
            {
                if (type.IsDefined(typeof(FlagsAttribute), true))
                    value = EditorGUILayout.EnumMaskField(name, (Enum)getValue);
                else
                    value = EditorGUILayout.EnumPopup(name, (Enum)getValue);
            }
            return value;
        }
    }
}