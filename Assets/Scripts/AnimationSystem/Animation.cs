using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using State = JSB.AnimationSystem.AnimationState;

namespace JSB.AnimationSystem
{
    public enum AnimationState
    {
        Unset, New, Again, Acting, Paused, Finished
    }

    public enum BlendMode
    { 
        Base, Additive, Subtractive
    }
    
    public abstract class Animation : IRegisterable
    {
        public float duration = 0;
        public int repetition = 1;
        public int residualRepetition = 0;

        protected State state = State.Unset;
        public State State { get => state; }
        protected GameObject go;
        protected Timer timer;

        // 核心函数 Core functions

        public void Register()
        {
            if (IsRegistered()) return;
            SetState(State.New);
            RegisterToController();
        }

        public abstract void RegisterToController();
        public abstract bool IsRegistered();

        public virtual float GetTime() => timer.Time();

        // 状态函数 Functions for states

        protected virtual void ToNewState()
        {
            residualRepetition = repetition;
            timer = new();
        }
        protected virtual void ToAgainState() => timer = new();
        protected virtual void ToActingState() => timer.Start();
        protected virtual void ToPausedState() => timer.Pause();

        public void SetState(State newState)
        {
            if (state == newState) return;
            switch (newState)
            {
                case State.New:
                    ToNewState();
                    break;
                case State.Again:
                    ToAgainState();
                    break;
                case State.Acting:
                    ToActingState();
                    break;
                case State.Paused:
                    ToPausedState();
                    break;
            }
            state = newState;
        }

        public virtual void UpdateState()
        {
            if (timer.Time() > duration) SetState(State.Finished);
        }

        // 初始参数设置函数 Functions for setting initial arguments

        public virtual Animation SetGameobject(GameObject go){ this.go = go; return this; }
        public virtual Animation SetDuration(float duration){ this.duration = duration; return this; }
        public virtual Animation SetRepetition(int repetition){ this.repetition = repetition; return this; }

        // 便捷函数 Functions for convenience

        public void Act()
        {
            Register();
            SetState(State.Acting);
        }

        public void ActOn(GameObject go)
        {
            SetGameobject(go);
            Act();
        }

        public virtual SequentialGroupAnimation Append(Animation next)
        {
            SequentialGroupAnimation group = new();
            group.Add(this);
            group.Add(next);
            return group;
        }
    }
}
