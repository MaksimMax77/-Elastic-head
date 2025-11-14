using UnityEngine;

namespace Code.AttackedObject.ImpactEffects
{
    [CreateAssetMenu(menuName = "Settings/ " + nameof(ImpactEffectsManagerSettings),
        fileName = nameof(ImpactEffectsManagerSettings))]
    public class ImpactEffectsManagerSettings : ScriptableObject
    {
        [SerializeField] private GameObject _effectPrefab;
        [SerializeField] private float _destroyTime;

        public GameObject EffectPrefab => _effectPrefab;
        public float DestroyTime => _destroyTime;
    }
}