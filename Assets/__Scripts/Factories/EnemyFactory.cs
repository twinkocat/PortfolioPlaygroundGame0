using ECS;
using Entities;
using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Factories
{
    public class EnemyFactory : EntityFactory
    {
        private List<Entity>    _enemyList = new List<Entity>(); 

        public override void Init()
        {
            var prefab1 = Resources.Load<BlueEnemyEntity>("Prefabs/BlueEnemy");
            var prefab2 = Resources.Load<RedEnemyEntity>("Prefabs/RedEnemy");

            _enemyList.Add(prefab1);
            _enemyList.Add(prefab2);
        }

        public override Entity FactoryMethod()
        {
            if (_enemyList.Count == 0)
            {
                Debug.LogError("No enemy prefabs loaded!");
                return null;
            }
            var rndNum = Random.Range(0, _enemyList.Count);
            var go = GameObject.Instantiate(_enemyList[rndNum]);

            return go;
        }
    }
}
