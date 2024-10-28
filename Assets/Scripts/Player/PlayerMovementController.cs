using Fusion;
using Fusion.Addons.KCC;
using MKubiak.RTETestTask.Input;
using UnityEngine;

namespace MKubiak.RTETestTask
{
    public class PlayerMovementController : NetworkBehaviour
    {
        [SerializeField] private bool _inversePitch;

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
            // '-'x so the pitch normally comes as input up is camera going up, and input down is camera going down. If preferred, it can be reverted with _inversePitch.
            var lookInput = new Vector2(-PlayerInput.Look.x * (_inversePitch ? -1f : 1f), PlayerInput.Look.y); 
            _motor.AddLookRotation(lookInput);

            Vector3 inputDirection = _motor.Data.TransformRotation * new Vector3(PlayerInput.Movement.x, 0.0f, PlayerInput.Movement.y);
            _motor.SetInputDirection(inputDirection);
        }
    }
}