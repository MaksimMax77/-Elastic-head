using Code.Pool;
using UnityEngine;
using Zenject;

namespace Code.Installers
{
    public class ObjectPoolsManagerInstaller : MonoInstaller
    {
        [SerializeField] private int _defaultPoolSize = 10;

        public override void InstallBindings()
        {
            Container.Bind<ObjectPoolsManager>()
                .AsSingle()
                .WithArguments(_defaultPoolSize);
        }
    }
}