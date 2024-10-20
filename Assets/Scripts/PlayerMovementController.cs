using Fusion;
using Fusion.Addons.KCC;
using MKubiak.RTETestTask.Input;
using UnityEngine;

namespace MKubiak.RTETestTask
{
    public class PlayerMovementController : NetworkBehaviour
    {
        private KCC _motor;

        private void Awake()
        {
            _motor = GetComponent<KCC>();
        }

        public override void FixedUpdateNetwork()
        {
            if (Runner.TryGetInputForPlayer(Object.InputAuthority, out PlayerInput input) == true)
            {
                _motor.AddLookRotation(input.Look);

                Vector3 inputDirection = _motor.Data.TransformRotation * new Vector3(input.Movement.x, 0.0f, input.Movement.y);
                _motor.SetInputDirection(inputDirection);
            }
        }
    }
}