using Components;
using ECS;
using UnityEngine;


namespace Systems
{
    public sealed class AnimationSystem : ILateUpdateSystem
    {
        private enum AnimationState
        {
            IDLE,
            MOVE,
        }

        private static readonly int STATE = Animator.StringToHash("State");

        private ComponentPool<AnimatorComponent>    _animatorPool;
        private ComponentPool<MoveStateComponent>   _movePool;

        void ILateUpdateSystem.OnLateUpdate(int entity)
        {
            if (!this._animatorPool.HasComponent(entity) || !this._movePool.HasComponent(entity))
            {
                return;
            }
            ref AnimatorComponent animatorComponent = ref this._animatorPool.GetComponent(entity);
            ref MoveStateComponent moveStateComponent = ref this._movePool.GetComponent(entity);

            if (moveStateComponent.moveRequired)
            {
                animatorComponent.value.SetInteger(STATE, (int)AnimationState.MOVE);
            }
            else
            {
                animatorComponent.value.SetInteger(STATE, (int)AnimationState.IDLE);
            }
        }
    }
}
