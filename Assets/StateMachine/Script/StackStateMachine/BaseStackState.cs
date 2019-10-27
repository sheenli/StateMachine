namespace YKFramework.StateMachine
{

    public interface IStackState : IState
    {
        
    }
    public abstract class BaseStackState : IState
    {
        public uint StateId
        {
            get { return 0; }
        }

        public void OnEnter(IState prevState, object param1 = null, object param2 = null)
        {
            OnEnter(prevState, (ChangeStateType) param1,param2);
        }

        public void OnLeave(IState nextState, object param1 = null, object param2 = null)
        {
            OnLeave(nextState, (ChangeStateType) param1,param2);
        }
        
        protected abstract void OnEnter(IState prevState, ChangeStateType type, object param1 = null);
        protected abstract void OnLeave(IState prevState, ChangeStateType type, object param1 = null);
        
        public abstract void OnUpdate();

        public abstract void OnFixedUpdate();

        public abstract void OnLateUpdate();
    }
}