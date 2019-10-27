using UnityEngine;
using System.Collections;

namespace YKFramework.StateMachine
{
    public interface IState
    {
        uint StateId { get;}

        /// <summary>
        /// 进入这个状态
        /// </summary>
        /// <param name="prevState">上一次的状态</param>
        /// <param name="param1">参数1</param>
        /// <param name="param2">参数2</param>
        void OnEnter(IState prevState, object param1 = null, object param2 = null);

        /// <summary>
        /// 离开这个状态
        /// </summary>
        /// <param name="nextState">下一状态</param>
        /// <param name="param1">参数1</param>
        /// <param name="param2">参数2</param>
        void OnLeave(IState nextState, object param1 = null, object param2 = null);

        void OnUpdate();
        void OnFixedUpdate();
        void OnLateUpdate();
    }
}

