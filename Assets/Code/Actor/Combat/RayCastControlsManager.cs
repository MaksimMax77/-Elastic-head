using System.Collections.Generic;

namespace Code.Actor.Combat
{
    public class RayCastControlsManager
    {
        private List<RayCastControl> _rayCastControls = new();

        public RayCastControlsManager(RayCastControlsManagerSettings rayCastControlsManagerSettings)
        {
            var configs = rayCastControlsManagerSettings.RaycastConfigurations;
            var len = configs.Length;
            for (var i = 0; i < len; i++)
            {
                var newRayCastControl = new RayCastControl(configs[i]);
                _rayCastControls.Add(newRayCastControl);
            }
        }

        public RayCastControl GetRayCastControlByIndex(int index)
        {
            return _rayCastControls[index];
        }

        public int GetRayCastControlCount()
        {
            return _rayCastControls.Count;
        }
    }
}