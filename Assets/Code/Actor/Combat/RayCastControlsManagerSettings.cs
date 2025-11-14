using UnityEngine;

namespace Code.Actor.Combat
{
    public class RayCastControlsManagerSettings : MonoBehaviour
    {
        [SerializeField] private RayCastConfiguration[] _raycastConfigurations;
        public RayCastConfiguration[] RaycastConfigurations => _raycastConfigurations;
    }
}