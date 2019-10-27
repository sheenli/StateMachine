

using UnityEngine;

namespace YKFramework.StateMachine.Example
{
    public class UIMgr : StackMachineComponeent<BaseUI>
    {
        public BaseUI defUI;
        [SerializeField]
        RectTransform mBorder;
        
        Rect mStart;
        Rect mTarget;

        private void Awake()
        {
            BetweenSwitchState = (from, to, param1, param2) =>
            {
                StartTween(to as BaseStackStateComponent);
            };
            for (int i = 0; i < this.transform.childCount; i++)
            {
                if(this.transform.GetChild(i).GetComponent<BaseUI>())
                    this.transform.GetChild(i).gameObject.SetActive(false);
            }
            SwitchWind(defUI);
        }

        public void SwitchWind(BaseUI newUI)
        {
            Push(newUI);
        }

        public void CloseCurrentWind()
        {
            Pop();
        }
        
        float mProgress;

        protected override void OnUpdate()
        {
            base.OnUpdate();
            if (mProgress < 1)
            {
                mProgress = Mathf.Clamp01(mProgress + Time.unscaledDeltaTime / 0.3f);
                SetBorderWorldRect(Lerp(mStart, mTarget, Mathf.SmoothStep(0, 1, mProgress)));
            }
        }
        
        void SetBorderWorldRect(Rect rect)
        {
            rect.min = RectTransformUtility.WorldToScreenPoint(null, rect.min);
            rect.max = RectTransformUtility.WorldToScreenPoint(null, rect.max);

            mBorder.offsetMin = rect.min;
            mBorder.offsetMax = rect.min + rect.size / mBorder.lossyScale;
        }
        
        public Rect Lerp(Rect a, Rect b, float t)
        {
            return new Rect(
                Vector2.Lerp(a.position, b.position, t),
                Vector2.Lerp(a.size, b.size, t));
        }
        
        void StartTween(BaseStackStateComponent targetState)
        {
            
            mStart = GetWorldRect(mBorder);
            mTarget = GetWorldRect(targetState.transform as RectTransform);
            mProgress = 0f;
        }
        
        public Rect GetWorldRect(RectTransform rectTransform)
        {
            var rect = rectTransform.rect;
            rect.min = rectTransform.TransformPoint(rect.min);
            rect.max = rectTransform.TransformPoint(rect.max);
            return rect;
        }
    }
}