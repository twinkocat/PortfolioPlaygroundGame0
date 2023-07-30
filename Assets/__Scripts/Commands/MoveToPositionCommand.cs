using System;
using UnityEngine;

namespace Commands
{
    [Serializable]
    public struct MoveToPositionCommand
    {
        public Vector3 destination;
    }
}
