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
        public abstract void OnEnter(IState prevState, object param1 = null, object param2 = null);

        public abstract void OnLeave(IState nextState, object param1 = null, object param2 = null);

        public abstract void OnUpdate();

        public abstract void OnFixedUpdate();

        public abstract void OnLateUpdate();
    }
}