using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace JSB.HazardSystem
{
    public class HazardFactoryManager
    {
        private static HazardFactoryManager inst;
        
        public static void Init()
        {
            if (inst != null) return;
            inst = new HazardFactoryManager();
            string prefix = Application.dataPath;
            BarrageFactory.squarePrefab = PrefabUtility.LoadPrefabContents(prefix + "/Prefabs/Hazards/Square.prefab");
        }
    }
}
