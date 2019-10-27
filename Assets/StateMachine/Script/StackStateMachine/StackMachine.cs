using System;
using System.Collections.Generic;
using UnityEngine;

namespace YKFramework.StateMachine
{
    public class StackMachine<T> : IDisposable  where T : IStackState
    {
        public BetweenSwitchState BetweenSwitchState { get; set; }
        private List<T> mStates = new List<T>(4);
        public double CurrentStateTime { get; private set; }

        public T CurrentState
        {
            get
            {
                if (mStates.Count <= 0) return default(T);
                return mStates[mStates.Count - 1];
            }
        }

        public T UnderState
        {
            get
            {
                if (mStates.Count < 2) return default(T);
                return mStates[mStates.Count - 2];
            }
        }

        public int StateNum
        {
            get { return mStates.Count; }
        }

        public T GetState(int index)
        {
            if (mStates.Count > index)
            {
                return mStates[index];
            }

            return default(T);
        }

        public void Push(T state,object param1 = null,object param2 = null)
        {
            if (state == null)
            {
                throw new Exception("压入堆栈的状态不能是空状态");
            }
            
            T old = default(T);
            if (CurrentState != null)
            {
                old = CurrentState;
                CurrentState.OnLeave(state,param1,param2);
            }

            if (BetweenSwitchState != null) BetweenSwitchState(old, state, param1, param2);
            CurrentStateTime = 0;
            mStates.Add(state);
            if (CurrentState != null) 
                CurrentState.OnEnter(old, param1, param2);
            
            
        }

        public void Pop(int needPopCunt = 1,object param1 = null,object param2 = null)
        {
            if(needPopCunt > StateNum) throw new Exception("要弹出的个数超出总个数");
            T next = default(T);
            T old = default(T);
            if (StateNum > needPopCunt)
            {
                next = mStates[StateNum - needPopCunt];
            }
            for (int i = 0; i < needPopCunt; i++)
            {
                old = mStates[StateNum - i - 1];
                old.OnLeave(next,param1,param2);
                mStates.RemoveAt(StateNum - i - 1);
            }
            if(next != null) next.OnEnter(old,param1,param2);

            if (BetweenSwitchState != null) BetweenSwitchState(next, old, param1, param2);
        }
        

        public void Update()
        {
            if (StateNum > 0)
            {
                CurrentStateTime += Time.deltaTime;
                CurrentState.OnUpdate();
            }

            OnUpdate();
        }

        public void LateUpdate()
        {
            if (StateNum > 0)
            {
                CurrentState.OnLateUpdate();
            }
            OnUpdate();
        }

        public void FixedUpdate()
        {
            if (StateNum > 0)
            {
                CurrentState.OnFixedUpdate();
            }

            OnFixedUpdate();
        }


        protected virtual void OnUpdate()
        {
            
        }

        protected virtual void OnLateUpdate()
        {
            
        }
        
        protected virtual void OnFixedUpdate()
        {
            
        }

        public void Dispose()
        {
            if(StateNum > 0) CurrentState.OnLeave(null);
            mStates.Clear();
        }
    }
}