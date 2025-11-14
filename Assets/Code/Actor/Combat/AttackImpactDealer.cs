using System;
using UnityEngine;
using Zenject;

namespace Code.Actor.Combat
{
    public class AttackImpactDealer : IDisposable, IFixedTickable
    {
        private AttackImpact _attackImpact;
        private RayCastControl _currentRayCastControl;
        private bool _rayCastEnabled;

        private AttackImpactDealer(AttackImpact attackImpact)
        {
            _attackImpact = attackImpact;
        }

        public void Dispose()
        {
            if (_currentRayCastControl != null)
            {
                _currentRayCastControl.OnHit -= OnRayCastHit;
            }
        }

        public void SetCurrentRayCastControlAndSubscribe(RayCastControl rayCastControl)
        {
            if (_currentRayCastControl != null)
            {
                _currentRayCastControl.OnHit -= OnRayCastHit;
            }

            _currentRayCastControl = rayCastControl;
            _currentRayCastControl.OnHit += OnRayCastHit;
        }

        private void OnRayCastHit(RaycastHit hit)
        {
            _attackImpact.Apply(hit);
            _rayCastEnabled = false;
        }

        public void FixedTick()
        {
            if (!_rayCastEnabled || _currentRayCastControl == null)
            {
                return;
            }

            _currentRayCastControl.Tick();
        }

        public void SetEnableRayCast(bool value)
        {
            _rayCastEnabled = value;
        }
    }
}