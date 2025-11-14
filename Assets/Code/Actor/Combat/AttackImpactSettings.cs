using UnityEngine;

namespace Code.Actor.Combat
{
    [CreateAssetMenu(menuName = "Settings/ " + nameof(AttackImpactSettings),
        fileName = nameof(AttackImpactSettings))]
    public class AttackImpactSettings : ScriptableObject
    {
        [SerializeField] private float _pressureForce = 10f;
        [SerializeField] private float _pressureOffset = 0.1f;

        public float PressureForce => _pressureForce;
        public float PressureOffset => _pressureOffset;
    }
}