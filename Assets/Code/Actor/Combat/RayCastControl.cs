using System;
using UnityEngine;

namespace Code.Actor.Combat
{
    public class RayCastControl
    {
        public event Action<RaycastHit> OnHit;
        private float _rayLength = 1f;
        private LayerMask _interactLayers;
        private Transform _origin;

        public RayCastControl(RayCastConfiguration configuration)
        {
            _rayLength = configuration.rayLength;
            _interactLayers = configuration.interactLayers;
            _origin = configuration.rayOrigin;
        }

        public void Tick()
        {
            var start = _origin.position;
            var dir = _origin.forward;

            if (Physics.Raycast(start, dir, out var hit, _rayLength, _interactLayers))
            {
                OnHit?.Invoke(hit);
            }
        }
    }
}