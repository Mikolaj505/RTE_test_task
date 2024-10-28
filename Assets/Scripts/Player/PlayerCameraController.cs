using Fusion;
using Fusion.Addons.KCC;
using MKubiak.Services;
using UnityEngine;

namespace MKubiak.RTETestTask
{
    public class PlayerCameraController : NetworkBehaviour
    {
        [SerializeField] private Transform _cameraTarget;

        private KCC _motor;

        private void Awake()
        {
            _motor = GetComponent<PlayerFacade>().Motor;
        }

        public override void Spawned()
        {
            // Only execute on locally controlled runner
            if (HasInputAuthority == false)
            {
                return;
            }

            ServiceLocator.Get<ICameraService>().AssignPlayerCamera(_cameraTarget);
        }

        public override void Render()
        {
            if (HasInputAuthority == false)
            {
                return;
            }

            var motorRotation = _motor.GetLookRotation();
            _cameraTarget.localRotation = Quaternion.Euler(motorRotation.x , 0, 0);
        }
    }
}