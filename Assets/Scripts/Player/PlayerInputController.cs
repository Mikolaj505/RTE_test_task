using deVoid.Utils;
using Fusion;
using UnityEngine;

namespace MKubiak.RTETestTask.Input
{
    public class PlayerInputController : NetworkBehaviour, IBeforeTick
    {
        [SerializeField] private PlayerInputActions _inputActions;

        [SerializeField] private float _mouseSensitivity = 5f;

        private PlayerInput _playerInput;

        private PlayerInput _previousNetworkInput;
        private PlayerInput _networkInput;

        public PlayerInput NetworkInput => _networkInput;

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
            networkInput.Set(_playerInput);

            _playerInput = new PlayerInput();
        }

        public override void Render()
        {
            var lookInput = _inputActions.PlayerMap.Look.ReadValue<Vector2>() * _mouseSensitivity;
            var reversedLookInput = new Vector2(lookInput.y, lookInput.x);

            _playerInput.Movement = _inputActions.PlayerMap.Movement.ReadValue<Vector2>();
            _playerInput.Look += reversedLookInput;
            _playerInput.Interact |= _inputActions.PlayerMap.Interact.IsPressed();
            _playerInput.Fire |= _inputActions.PlayerMap.Fire.IsPressed();
            _playerInput.ShowUI |= _inputActions.PlayerMap.ShowUI.IsPressed();
        }

        void IBeforeTick.BeforeTick() 
        {
            _previousNetworkInput = _networkInput;

            if (Object.InputAuthority == PlayerRef.None)
            {
                return;
            }

            if (Runner.TryGetInputForPlayer(Object.InputAuthority, out PlayerInput playerInput))
            {
                _networkInput = playerInput;
            }
        }

        public bool WasActivated(PlayerInputAction action)
        {
            return action.WasActivated(_networkInput, _previousNetworkInput);
        }
    }
}
