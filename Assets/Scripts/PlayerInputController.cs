using Fusion;
using UnityEngine;

namespace MKubiak.RTETestTask.Input
{
    public class PlayerInputController : MonoBehaviour
    {
        [SerializeField] private PlayerInputActions _inputActions;

        public PlayerInput PlayerInput { get; private set; }

        private void Awake()
        {
            _inputActions = new PlayerInputActions();
            _inputActions.PlayerMap.Enable();
        }

        private void Update()
        {
            PlayerInput = new()
            {
                Movement = _inputActions.PlayerMap.Movement.ReadValue<Vector2>(),
                Look = _inputActions.PlayerMap.Look.ReadValue<Vector2>()
            };

            Debug.Log($"Movement {PlayerInput.Movement}, Look {PlayerInput.Look}");
        }
    }

    public struct PlayerInput : INetworkInput
    {
        public Vector2 Movement;
        public Vector2 Look;
    }
}
