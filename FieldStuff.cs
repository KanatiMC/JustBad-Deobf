using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace JustBad
{
    internal class FieldStuff : MonoBehaviour
    {
        internal static void smethod_0(int typemdt)
        {
            Type type = module_0.ResolveType(33554432 + typemdt);
            foreach (FieldInfo fieldInfo in type.GetFields())
            {
                MethodInfo methodInfo = (MethodInfo)module_0.ResolveMethod(fieldInfo.MetadataToken + 100663296);
                fieldInfo.SetValue(null, (MulticastDelegate)Delegate.CreateDelegate(type, methodInfo));
            }
        }

        internal static Module module_0 = typeof(FieldStuff).Assembly.ManifestModule;

        internal delegate void Delegate0(object o);
    }
}
