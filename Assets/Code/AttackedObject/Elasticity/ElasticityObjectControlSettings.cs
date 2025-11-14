using UnityEngine;

namespace Code.AttackedObject.Elasticity
{
    [CreateAssetMenu(menuName = "Settings/ " + nameof(ElasticityObjectControlSettings),
        fileName = nameof(ElasticityObjectControlSettings))]
    public class ElasticityObjectControlSettings : ScriptableObject
    {
        [SerializeField] private float _bounceSpeed = 100;
        [SerializeField] private float _stiffness = 5;

        public float BounceSpeed => _bounceSpeed;
        public float Stiffness => _stiffness;
    }
}