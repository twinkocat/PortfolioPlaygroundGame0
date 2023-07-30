using Commands;
using Components;
using ECS;
using Systems;
using UnityEngine;


namespace RTSGame
{
    public sealed class EcsManager : MonoBehaviour
    {
        public EcsWorld EcsWorld => _ecsWorld;

        private EcsWorld _ecsWorld = new();

        [SerializeField] private Entity _playerEntity;


        private void Awake()
        {
            ComponentsBinding();
            SystemsBinding();

            this._ecsWorld.Install();

            _playerEntity.Init(_ecsWorld);
        }

        private void SystemsBinding()
        {
            this._ecsWorld.BindSystem<MovementSystem>();
            this._ecsWorld.BindSystem<AnimationSystem>();
            this._ecsWorld.BindSystem<MoveToPositionSystem>();
        }

        private void ComponentsBinding()
        {
            this._ecsWorld.BindComponent<MoveStateComponent>();
            this._ecsWorld.BindComponent<MoveSpeedComponent>();
            this._ecsWorld.BindComponent<TransformComponent>();
            this._ecsWorld.BindComponent<AnimatorComponent>();

            this._ecsWorld.BindComponent<MoveToPositionCommand>();
        }

        private void Update()
        {
            _ecsWorld.Update();
        }

        private void FixedUpdate()
        {
            _ecsWorld.FixedUpdate();
        }

        private void LateUpdate()
        {
            _ecsWorld.LateUpdate();
        }
    }

}