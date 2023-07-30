using Commands;
using ECS;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace RTSGame
{
    public sealed class MoveController : MonoBehaviour
    {
        [SerializeField] private List<Entity> _entity;

        [SerializeField] private Transform       destination;

        public void AddEntity(Entity entity)
        {
            _entity.Add(entity);
        }

        [ContextMenu("MoveToPoint")]
        public void MoveToPoint()
        {
            foreach (var entity in _entity)
            {
                entity.SetData(new MoveToPositionCommand
                {
                    destination = destination.position
                });
            }
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(MoveController))]
    public class MoveControllerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            MoveController myScript = (MoveController)target;


            GUILayout.Space(20f);
            if (GUILayout.Button("Move"))
            {
                myScript.MoveToPoint();
            }
        }
    }
#endif
}
