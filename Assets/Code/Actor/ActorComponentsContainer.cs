using Code.Actor.Animation;
using UnityEngine;

namespace Code.Actor
{
    public class ActorComponentsContainer : MonoBehaviour
    {
        [SerializeField] private AnimationEventHandler _animationEventHandler;
        [SerializeField] private Animator _animator;

        public AnimationEventHandler AnimationEventHandler => _animationEventHandler;
        public Animator Animator => _animator;
    }
}