using System;
using UnityEngine;

namespace Code.Actor.Combat
{
    [Serializable]
    public class RayCastConfiguration
    {
        public float rayLength = 1f;
        public LayerMask interactLayers;
        public Transform rayOrigin;
    }
}