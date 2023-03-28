using System;
using UnityEngine;

namespace Core.Movement.Data
{
    [Serializable]
    public class HorizontalMovementData
    {
        [field: SerializeField] public float HorizontalSpeed { get; private set; }
        [field: SerializeField] public bool IsFaceRight { get;  set; }
    }
}