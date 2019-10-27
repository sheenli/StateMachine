using System;
using UnityEngine.Events;

namespace YKFramework.StateMachine
{
    [Serializable]
    public class StateUityEvent:UnityEvent<IState,object,object> {}
}