using Code.AttackedObject.Elasticity;
using Code.AttackedObject.ImpactEffects;
using UnityEngine;
using Zenject;

namespace Code.Installers
{
    public class HeadInstaller : MonoInstaller
    {
        [SerializeField] private ElasticityObject _elasticityObject;
        [SerializeField] private ImpactEffectSource _impactEffectSource;
        [SerializeField] private ElasticityObjectControlSettings _elasticityObjectControlSettings;
        [SerializeField] private ImpactEffectsManagerSettings _impactEffectsManagerSettings;

        public override void InstallBindings()
        {
            Container.Bind<ElasticityObject>().FromInstance(_elasticityObject).AsSingle();
            Container.Bind<ElasticityObjectControlSettings>().FromInstance(_elasticityObjectControlSettings).AsSingle();
            Container.BindInterfacesAndSelfTo<ElasticityObjectControl>().AsSingle().NonLazy();

            Container.Bind<ImpactEffectSource>().FromInstance(_impactEffectSource).AsSingle();
            Container.Bind<ImpactEffectsManagerSettings>().FromInstance(_impactEffectsManagerSettings).AsSingle();
            Container.BindInterfacesAndSelfTo<ImpactEffectsManager>().AsSingle().NonLazy();
        }
    }
}