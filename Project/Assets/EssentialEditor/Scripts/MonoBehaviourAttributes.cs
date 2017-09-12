using UnityEngine;
using System;
using System.Collections;

namespace EssentialEditor
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ExposePropertyAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class ExposeMethodAttribute : Attribute
    {
    }
}