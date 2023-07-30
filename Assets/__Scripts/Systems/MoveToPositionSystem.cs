using Commands;
using Components;
using ECS;

namespace Systems
{
    public sealed class MoveToPositionSystem : IFixedUpdateSystem
    {
        private const float MIN_SQR_DISTANCE = 0.01f;

        private ComponentPool<MoveToPositionCommand>    _commandPool;
        private ComponentPool<MoveStateComponent>       _movePool;
        private ComponentPool<TransformComponent>       _transformPool;

        void IFixedUpdateSystem.OnFixedUpdate(int entity)
        {
            if (!this._commandPool.HasComponent(entity))
            {
                return;
            }

            ref MoveToPositionCommand command = ref this._commandPool.GetComponent(entity);
            ref MoveStateComponent moveComponent = ref this._movePool.GetComponent(entity);
            ref TransformComponent transformComponent = ref this._transformPool.GetComponent(entity);

            var endPosition = command.destination;
            var myPosition = transformComponent.value.position;

            var distanceVector = endPosition - myPosition;

            if (distanceVector.sqrMagnitude > MIN_SQR_DISTANCE)
            {
                moveComponent.moveRequired = true;
                moveComponent.direction = distanceVector.normalized;
            }
            else
            {
                this._commandPool.RemoveComponent(entity);
            }
        }
    }
}
