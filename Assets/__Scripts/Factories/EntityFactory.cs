using ECS;
using System;

namespace Factories
{
    public abstract class EntityFactory
    {
        public abstract void Init();
        public abstract Entity FactoryMethod();
    }
}
