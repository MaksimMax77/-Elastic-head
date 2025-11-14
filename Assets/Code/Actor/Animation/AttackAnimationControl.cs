using System;
using UnityEngine;

namespace Code.Actor.Animation
{
    public class AttackAnimationControl : IDisposable
    {
        public event Action<bool> AttackAnimationStateChanged;
        private string _attackHitEventName = "Hit";
        private string _attackEndEventName = "AttackEnd";
        private string[] _animationTransitionsNames;
        private Animator _animator;
        private AnimationEventHandler _animationEventHandler;

        private AttackAnimationControl(AttackAnimationControlSettings settings,
            ActorComponentsContainer actorComponentsContainer)
        {
            _attackHitEventName = settings.AttackHitEventName;
            _attackEndEventName = settings.AttackEndEventName;
            _animationTransitionsNames = settings.AnimationTransitionsNames;
            _animator = actorComponentsContainer.Animator;
            _animationEventHandler = actorComponentsContainer.AnimationEventHandler;
            _animationEventHandler.AnimationEventInvoked += OnAnimationEventInvoked;
        }

        public void Dispose()
        {
            _animationEventHandler.AnimationEventInvoked -= OnAnimationEventInvoked;
        }

        private void OnAnimationEventInvoked(string eventName)
        {
            if (eventName.Equals(_attackHitEventName))
            {
                AttackAnimationStateChanged?.Invoke(true);
                return;
            }

            if (eventName.Equals(_attackEndEventName))
            {
                AttackAnimationStateChanged?.Invoke(false);
            }
        }

        public void ShowAttackAnimation(int transitionIndex)
        {
            _animator.SetTrigger(_animationTransitionsNames[transitionIndex]);
        }
    }
}