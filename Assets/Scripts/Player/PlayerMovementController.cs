using Fusion;
using Fusion.Addons.KCC;
using MKubiak.RTETestTask.Input;
using UnityEngine;

namespace MKubiak.RTETestTask
{
    public class PlayerMovementController : NetworkBehaviour
    {
        private KCC _motor;
        private PlayerInputController _inputController;

        private PlayerInput PlayerInput => _inputController.NetworkInput;

        private void Awake()
        {
            var playerFacade = GetComponent<PlayerFacade>();

            _motor = playerFacade.Motor;
            _inputController = playerFacade.Input;
        }

        public override void FixedUpdateNetwork()
        {
            _motor.AddLookRotation(PlayerInput.Look);

            Vector3 inputDirection = _motor.Data.TransformRotation * new Vector3(PlayerInput.Movement.x, 0.0f, PlayerInput.Movement.y);
            _motor.SetInputDirection(inputDirection);
        }
    }
}