using System;
using UnityEngine;

namespace Core.Movement.Data
{
    [Serializable]
    public class JumperData
    {
        [field: SerializeField] public float JumpForce { get; private set; }
        [field: SerializeField] public Transform GroundCheck { get; private set; }
        [field: SerializeField] public LayerMask GroundLayer { get; private set; }

    }
}