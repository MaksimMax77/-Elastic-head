using Code.Actor;
using Code.Actor.Animation;
using Code.Actor.Combat;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Code.Installers
{
    public class ActorInstaller : MonoInstaller
    {
        [SerializeField] private ActorComponentsContainer _actorComponentsContainer;
        [SerializeField] private RayCastControlsManagerSettings _rayCastControlsManagerSettings;
        [SerializeField] private AttackImpactSettings _attackImpactSettings;
        [SerializeField] private AttackAnimationControlSettings _animationControlSettings;
        
        public override void InstallBindings()
        {
            Container.Bind<DefaultInputActions>().AsSingle();
            Container.Bind<RayCastControlsManagerSettings>().FromInstance(_rayCastControlsManagerSettings).AsSingle();
            Container.Bind<RayCastControlsManager>().AsSingle();

            Container.Bind<ActorComponentsContainer>().FromInstance(_actorComponentsContainer).AsSingle();
            Container.Bind<AttackAnimationControlSettings>().FromInstance(_animationControlSettings).AsSingle();
            Container.BindInterfacesAndSelfTo<AttackAnimationControl>().AsSingle();

            Container.Bind<AttackImpactSettings>().FromInstance(_attackImpactSettings).AsSingle();
            Container.Bind<AttackImpact>().AsSingle();
            Container.BindInterfacesAndSelfTo<AttackImpactDealer>().AsSingle();
            Container.BindInterfacesAndSelfTo<AttackHandler>().AsSingle().NonLazy();
        }
    }
}