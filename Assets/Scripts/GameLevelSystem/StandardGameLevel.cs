using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JSB.GameLevelSystem
{
    public abstract class StandardGameLevel
    {
        protected List<ICommand> commands;
        protected int currentCommand = 0;

        protected Timer timer = new();
        protected float waitTo = 0;

        public void Load(string json) => commands = JsonUtility.FromJson<List<ICommand>>(json);

        public void ExecuteNextCommand() => commands[++currentCommand].Execute(this);
        public void Wait(float time) => waitTo += time;
        public bool IsWaiting() => timer.Time() < waitTo;
    }
}
