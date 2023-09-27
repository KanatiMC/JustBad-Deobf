using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace JustBad
{
    public class Loader : MonoBehaviour
    {
        public static void Init()
        {
            Loader._loadObject = new GameObject();
            Loader._loadObject.AddComponent<Menu>();
            Loader._loadObject.AddComponent<Class2>();
            Loader._loadObject.AddComponent<MovementCheats>();
            Loader._loadObject.AddComponent<MiscCheats>();
            Loader._loadObject.AddComponent<CombatCheats>();
            Loader._loadObject.AddComponent<Class1>();
            Object.DontDestroyOnLoad(Loader._loadObject);
        }

        // Token: 0x06000068 RID: 104 RVA: 0x0000A614 File Offset: 0x00008814
        public static void Unload()
        {
            Loader.smethod_0();
        }

        // Token: 0x06000069 RID: 105 RVA: 0x0000A628 File Offset: 0x00008828
        private static void smethod_0()
        {
            Object.Destroy(Loader._loadObject);
        }

        // Token: 0x040000BD RID: 189
        public static GameObject _loadObject;
    }
}
