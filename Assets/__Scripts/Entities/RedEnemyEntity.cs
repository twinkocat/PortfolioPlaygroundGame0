using Components;
using ECS;
using UnityEngine;

namespace Entities
{
    public class RedEnemyEntity : Entity
    {
        [SerializeField] private float _speed;

        protected override void OnInit()
        {
            this.SetData(new MoveSpeedComponent
            {
                value = this._speed
            });

            this.SetData(new TransformComponent
            {
                value = this.transform
            });

            this.SetData(new AnimatorComponent
            {
                value = this.GetComponent<Animator>()
            });

            this.SetData(new MoveStateComponent());
        }
    }
}
