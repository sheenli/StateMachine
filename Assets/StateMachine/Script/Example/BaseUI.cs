using UnityEngine;

namespace YKFramework.StateMachine.Example
{
    [AddComponentMenu("YKFramework/StateMachine/BaseUI")]
    [System.Serializable]
    public class BaseUI : BaseStackStateComponent
    {
        protected override void OnEnter(IState prevState, ChangeStateType type, object param1 = null)
        {
        }

        protected override void OnLeave(IState prevState, ChangeStateType type, object param1 = null)
        {
        }
    }
}