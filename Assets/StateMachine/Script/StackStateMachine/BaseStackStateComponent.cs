using UnityEngine;
using UnityEngine.Events;

namespace YKFramework.StateMachine
{
    [System.Serializable]
    public abstract class BaseStackStateComponent : MonoBehaviour, IStackState
    {
        public uint StateId
        {
            get
            {
                return 0;
            }
        }
        
        [SerializeField]
        protected StateUityEvent _OnEnter;
        
        public event UnityAction<IState,object,object> OnEentEvent
        {
            add
            {
                if(_OnEnter == null) _OnEnter = new StateUityEvent();
                _OnEnter.AddListener(value);
            }
            remove
            {
                if(_OnEnter != null) _OnEnter.RemoveListener(value);
            }
        }

        public virtual void OnEnter(IState prevState, object param1 = null, object param2 = null)
        {
            if(_OnEnter != null) _OnEnter.Invoke(prevState as IStackState, param1,param2);
        }

        
        [SerializeField]
        protected StateUityEvent _OnLeave;
        
        public event UnityAction<IState,object,object> OnLeaveEvent
        {
            add
            {
                if(_OnLeave == null) _OnLeave = new StateUityEvent();
                _OnLeave.AddListener(value);
            }
            remove
            {
                if(_OnLeave != null) _OnLeave.RemoveListener(value);
            }
        }

        public virtual void OnLeave(IState nextState, object param1 = null, object param2 = null)
        {
            if(_OnLeave != null) _OnLeave.Invoke(nextState as IStackState, param1,param2);
        }

        public virtual void OnUpdate(){}

        public virtual void OnFixedUpdate(){}

        public virtual void OnLateUpdate(){}

        private void OnDestroy()
        {
            _OnEnter = null;
            _OnLeave = null;
        }
    }
}