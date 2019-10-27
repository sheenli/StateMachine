using System;
using UnityEngine;
using UnityEngine.Events;

namespace YKFramework.StateMachine
{
    [DisallowMultipleComponent]
    public abstract class BaseComponentState: MonoBehaviour, IState
    {
        [SerializeField]
        private StateUityEvent _OnEnter;
        [SerializeField]
        private StateUityEvent _OnLeave;
        
        public event UnityAction<IState,object,object> onEnter
        {
            add
            {
                if (_OnEnter == null) _OnEnter = new StateUityEvent();
                _OnEnter.AddListener(value);
            }
            remove
            {
                if(_OnEnter != null) _OnEnter.RemoveListener(value);
            }
        }
        public event UnityAction<IState,object,object> onLeave
        {
            add
            {
                if (_OnLeave == null) _OnLeave = new StateUityEvent();
                _OnLeave.AddListener(value);
            }
            remove
            {
                if(_OnLeave != null) _OnLeave.RemoveListener(value);
            }
        }
        
        
        public void OnEnter(IState prevState, object param1 = null, object param2 = null)
        {
            if(_OnEnter != null) _OnEnter.Invoke(prevState,param1,param2);
        }

        public void OnLeave(IState nextState, object param1 = null, object param2 = null)
        {
            if(_OnLeave != null) _OnLeave.Invoke(nextState,param1,param2);
        }
        
        public abstract uint StateId { get;}
        public abstract void OnUpdate();

        public abstract void OnFixedUpdate();

        public abstract void OnLateUpdate();
    }
}