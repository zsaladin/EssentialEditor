using UnityEngine;
using System.Collections.Generic;

public class Test : MonoBehaviour
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
}
