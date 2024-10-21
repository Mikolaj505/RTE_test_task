using Fusion;
using Fusion.Addons.KCC;
using MKubiak.Services;
using UnityEngine;

namespace MKubiak.RTETestTask
{
    public class PlayerCameraController : NetworkBehaviour
    {
        [SerializeField] private Transform _cameraTarget;
        [SerializeField] private bool _inversePitch;

        private KCC _motor;

        private void Start()
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

            ServiceLocator.Get<CameraSerivce>().AssignPlayerCamera(_cameraTarget);
        }

        public override void Render()
        {
            if (HasInputAuthority == false)
            {
                return;
            }

            // '-' so the pitch normally comes as input up is camera going up, and input down is camera going down. If preferred, it can be reverted with _inversePitch.
            var motorRotation = -_motor.GetLookRotation();
            _cameraTarget.localRotation = Quaternion.Euler(motorRotation.x * (_inversePitch ? -1f : 1f) , 0, 0);
        }
    }
}