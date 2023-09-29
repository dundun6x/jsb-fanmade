using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using JSB.GameLevelSystem;
using JSB.HazardSystem;

namespace JSB
{
    public class GameManagerComponent : MonoBehaviour
    {
        private void Start()
        {
            HazardFactoryManager.Init();
            WorldChase level = new();
            level.Init();
            GameLevelController.GetInst().StartFreeLevel(level);
        }
    }
}
