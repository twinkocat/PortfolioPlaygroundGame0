using UnityEngine;

namespace ECS
{
    public class Entity : MonoBehaviour
    {
        public int Id => _id;

        private int _id;
        private EcsWorld _ecsWorld;

        public void Init(EcsWorld world)
        {
            this._id = world.CreateEntity();
            this._ecsWorld = world;
            this.OnInit();
        }

        protected virtual void OnInit() { }
        
        public void Dispose()
        {
            this._ecsWorld.DestroyEntity(this._id);
            this._ecsWorld = null;
            this._id = -1;
        }

        public void SetData<T>(T component) where T : struct
        {
            this._ecsWorld.SetComponent(this._id, ref component);
        }

        public ref T GetData<T>() where T : struct
        {
            return ref this._ecsWorld.GetComponent<T>(this._id);
        }
    }
}
