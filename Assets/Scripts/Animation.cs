using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JSB
{
    using State = AnimationState;
    
    public enum AnimationState
    {
        Idle, Acting, Paused, Finished
    }
    
    public abstract class Animation
    {
        protected State state = State.Idle;
        protected float duration = 0;
        protected Timer timer = new();
        protected GameObject go;

        public abstract void Register();
        public abstract bool IsRegistered();

        public virtual void SetGameobject(GameObject go) => this.go = go;
        public void SetDuration(float duration) => this.duration = duration;
        public float GetDuration() => duration;

        public virtual State GetState() => state;

        public virtual void UpdateState()
        {
            if (timer.Time() > duration) SetState(State.Finished);
        }

        public virtual void SetState(State newState)
        {
            if (newState == State.Acting) timer.Start();
            else if (newState == State.Paused) timer.Pause();
            state = newState;
        }

        public void ActOn(GameObject go)
        {
            SetGameobject(go);
            Register();
            SetState(State.Acting);
        }
    }
}
