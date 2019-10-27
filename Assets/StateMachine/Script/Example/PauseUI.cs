using UnityEngine;

namespace YKFramework.StateMachine.Example
{
    [AddComponentMenu("YKFramework/StateMachine/PauseUI")]
    [System.Serializable]
    public class PauseUI : BaseUI
    {
        public CanvasGroup canvasGroup;
        protected override void OnEnter(IState prevState, ChangeStateType type, object param1 = null)
        {
            if (type == ChangeStateType.Push)
            {
                this.gameObject.SetActive(true);
            }
            else
            {
                canvasGroup.blocksRaycasts = true;
            }
        }

        protected override void OnLeave(IState prevState, ChangeStateType type, object param1 = null)
        {
            if (type == ChangeStateType.Pop)
            {
                this.gameObject.SetActive(false);
            }
            else
            {
                canvasGroup.blocksRaycasts = false;
            }
        }
    }
}