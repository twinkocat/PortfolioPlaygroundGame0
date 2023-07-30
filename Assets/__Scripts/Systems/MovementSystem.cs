using Components;
using ECS;
using UnityEngine;

namespace Systems
{
    public sealed class MovementSystem : IFixedUpdateSystem
    {
        private ComponentPool<MoveStateComponent> _statePool;
        private ComponentPool<MoveSpeedComponent> _speedPool;
        private ComponentPool<TransformComponent> _transformPool;


        void IFixedUpdateSystem.OnFixedUpdate(int entity)
        {
            if (!this._statePool.HasComponent(entity))
            {
                return;
            }

            ref MoveStateComponent stateComponent = ref this._statePool.GetComponent(entity);

            if (!stateComponent.moveRequired)
            {
                return;
            }

            ref TransformComponent transformComponent = ref this._transformPool.GetComponent(entity);
            ref MoveSpeedComponent moveSpeedComponent = ref this._speedPool.GetComponent(entity);

            var direction = stateComponent.direction;
            var offset = direction * moveSpeedComponent.value * Time.fixedDeltaTime;
            transformComponent.value.position += offset;
            transformComponent.value.rotation = Quaternion.LookRotation(direction, Vector3.up);

            stateComponent.moveRequired = false;
        }
    }
}