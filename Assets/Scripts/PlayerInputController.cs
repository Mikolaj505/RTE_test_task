using deVoid.Utils;
using Fusion;
using UnityEngine;

namespace MKubiak.RTETestTask.Input
{
    public class PlayerInputController : NetworkBehaviour
    {
        [SerializeField] private PlayerInputActions _inputActions;

        public PlayerInput PlayerInput { get; private set; }

        private void Awake()
        {
            _inputActions = new PlayerInputActions();
            _inputActions.PlayerMap.Enable();
        }

        public override void Spawned()
        {
            if (HasInputAuthority)
            {
                // Register local player input polling.
                Signals.Get<OnInputSignal>().AddListener(OnInput);
            }
        }

        public override void Despawned(NetworkRunner runner, bool hasState)
        {
                Signals.Get<OnInputSignal>().RemoveListener(OnInput);
        }

        private void OnInput(NetworkRunner runner, NetworkInput networkInput)
        {
            networkInput.Set(PlayerInput);

            Debug.Log($"Player Input {PlayerInput.Movement} :: {PlayerInput.Look}");
        }

        public override void Render()
        {
            PlayerInput = new()
            {
                Movement = _inputActions.PlayerMap.Movement.ReadValue<Vector2>(),
                Look = _inputActions.PlayerMap.Look.ReadValue<Vector2>()
            };
        }
    }

    public struct PlayerInput : INetworkInput
    {
        public Vector2 Movement;
        public Vector2 Look;
    }
}
