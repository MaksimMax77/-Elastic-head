using System;
using Code.Actor.Animation;
using UnityEngine.InputSystem;

namespace Code.Actor.Combat
{
    public class AttackHandler : IDisposable
    {
        private AttackAnimationControl _attackAnimationControl;
        private AttackImpactDealer _attackImpactDealer;
        private DefaultInputActions _input;
        private RayCastControlsManager _rayCastControlsManager;

        private bool _isAttacking;
        private int _attackIndex;

        private AttackHandler(DefaultInputActions defaultInputActions,
            RayCastControlsManager rayCastControlsManager,
            AttackAnimationControl attackAnimationControl,
            AttackImpactDealer attackImpactDealer)
        {
            _input = defaultInputActions;
            _rayCastControlsManager = rayCastControlsManager;
            _attackAnimationControl = attackAnimationControl;
            _attackImpactDealer = attackImpactDealer;
            _input.Enable();
            _input.Player.Fire.started += OnFire;
            _attackAnimationControl.AttackAnimationStateChanged += OnAttackAnimationStateChanged;
        }

        public void Dispose()
        {
            _input.Player.Fire.started -= OnFire;
            _attackAnimationControl.AttackAnimationStateChanged -= OnAttackAnimationStateChanged;
        }

        private void OnFire(InputAction.CallbackContext context)
        {
            if (_isAttacking)
            {
                return;
            }

            ShiftAttackIndex();
            _attackAnimationControl.ShowAttackAnimation(_attackIndex);
            _attackImpactDealer.SetCurrentRayCastControlAndSubscribe(
                _rayCastControlsManager.GetRayCastControlByIndex(_attackIndex));
            _isAttacking = true;
        }

        private void ShiftAttackIndex()
        {
            _attackIndex++;
            if (_attackIndex == _rayCastControlsManager.GetRayCastControlCount())
            {
                _attackIndex = 0;
            }
        }

        private void OnAttackAnimationStateChanged(bool hitEnable)
        {
            _attackImpactDealer.SetEnableRayCast(hitEnable);
            if (!hitEnable)
            {
                _isAttacking = false;
            }
        }
    }
}