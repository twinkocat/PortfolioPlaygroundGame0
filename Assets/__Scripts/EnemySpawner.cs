using Factories;
using UnityEditor;
using UnityEngine;

namespace RTSGame
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private MoveController _moveController;
        [SerializeField] private EcsManager     _ecsManager;

        private EnemyFactory _enemyCreator = new();

        
        private void Awake()
        {
            _enemyCreator.Init();
        }

        [ContextMenu("Spawn")]
        public void Spawn()
        {
            var go = _enemyCreator.FactoryMethod();

            go.Init(_ecsManager.EcsWorld);

            _moveController.AddEntity(go);

            var spawnPos = Random.insideUnitSphere * 100f;
            go.transform.position = new Vector3(spawnPos.x, 0, spawnPos.z);
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(EnemySpawner))]
    public class EnemySpawnerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            EnemySpawner myScript = (EnemySpawner)target;


            GUILayout.Space(20f);

            if (GUILayout.Button("Spawn"))
            {
                myScript.Spawn();
            }
        }
    }
#endif
}
