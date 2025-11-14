using Code.AttackedObject.Elasticity;
using Code.AttackedObject.ImpactEffects;
using UnityEngine;

namespace Code.Actor.Combat
{
    public class AttackImpact
    {
        private float _pressureForce = 10f;
        private float _pressureOffset = 0.1f;

        public AttackImpact(AttackImpactSettings settings)
        {
            _pressureForce = settings.PressureForce;
            _pressureOffset = settings.PressureOffset;
        }

        public void Apply(RaycastHit hit)
        {
            var elasticity = hit.collider.GetComponent<ElasticityObject>();
            if (elasticity != null)
            {
                var point = hit.point + hit.normal * _pressureOffset;
                elasticity.Affect(point, _pressureForce);
            }
            
            var impactEffectSource = hit.collider.GetComponent<ImpactEffectSource>();
            if (impactEffectSource == null)
            {
                return;
            }
            impactEffectSource.ImpactInvoke(hit.point);
        }
    }
}