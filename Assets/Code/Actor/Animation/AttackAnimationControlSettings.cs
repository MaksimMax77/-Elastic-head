using UnityEngine;

namespace Code.Actor.Animation
{
    [CreateAssetMenu(menuName = "Settings/ " + nameof(AttackAnimationControlSettings),
        fileName = nameof(AttackAnimationControlSettings))]
    public class AttackAnimationControlSettings : ScriptableObject
    {
        [SerializeField] private string _attackHitEventName = "Hit";
        [SerializeField] private string _attackEndEventName = "AttackEnd";
        [SerializeField] private string[] _animationTransitionsNames;

        public string AttackHitEventName => _attackHitEventName;
        public string AttackEndEventName => _attackEndEventName;
        public string[] AnimationTransitionsNames => _animationTransitionsNames;
    }
}