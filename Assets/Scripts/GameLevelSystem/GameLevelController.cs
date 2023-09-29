using System.Collections;
using System.Collections.Generic;
using JSB.HazardSystem;
using Unity.VisualScripting;
using UnityEngine;

namespace JSB.GameLevelSystem
{
    public class GameLevelController : MonoBehaviour
    {
        private static GameLevelController inst;

        public static GameLevelController GetInst()
        {
            if (inst == null)
            {
                GameObject go = new GameObject("Game Level Controller");
                inst = go.AddComponent<GameLevelController>();
            }
            return inst;
        }

        private StandardGameLevel level;
        private bool isStarted = false;
        private bool isStandardLevel = false;

        public void StartStandardLevel(StandardGameLevel level)
        {
            if (isStarted) return;
            isStarted = true;
            isStandardLevel = true;
            this.level = level;
        }

        public void StartFreeLevel(FreeGameLevel level)
        {
            if (isStarted) return;
            isStarted = true;
            StartCoroutine(level.Perform());
        }

        private void Update()
        {
            if (!isStandardLevel) return;
            if (level.IsWaiting()) return;
            level.ExecuteNextCommand();
        }
    }
}
