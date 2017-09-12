using UnityEngine;
using System.Collections.Generic;

namespace EssentialEditor.Example
{
    public class Example : MonoBehaviour
    {
        public Vector2 foo1;
        public float foo2;

        [ExposeProperty]
        public float Foo
        {
            get { return foo2; }
            set { foo2 = value; }
        }

        [ExposeProperty]
        public Vector3 Foo2
        {
            get { return new Vector3(foo1.x, foo1.y, foo2); }
            set
            {
                foo1.x = value.x;
                foo1.y = value.y;
                foo2 = value.z;
            }
        }

        [ExposeProperty]
        public float Foo3 { get; set; }

        [ExposeProperty]
        public Vector2 Foo4
        {
            get { return foo1; }
        }

        [ExposeProperty]
        private Object Foo5 { get; set; }

        [ExposeMethod]
        void Goo1()
        {
            Debug.Log("Test");
        }

        [ExposeMethod]
        bool Goo2(int x, int y)
        {
            return x == 0;
        }

        [ExposeMethod]
        string Goo3(Object obj)
        {
            if (obj == null)
                return "Assign any object as an arguement";
            
            return obj.name;
        }

        [ExposeMethod]
        string Goo4()
        {
            if (Foo5 == null)
                return "Assign any object to 'Foo5' property";

            return Foo5.name;
        }
    }
}