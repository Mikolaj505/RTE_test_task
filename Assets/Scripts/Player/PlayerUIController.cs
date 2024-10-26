using Fusion;
using MKubiak.RTETestTask.Input;
using MKubiak.RTETestTask.PlayerUI;
using MKubiak.Services;

namespace MKubiak.RTETestTask
{
    public class PlayerUIController : NetworkBehaviour
    {
        private PlayerFacade _playerFacade;
        private PlayerInputController _inputController;

        private void Awake()
        {
            _playerFacade = GetComponent<PlayerFacade>();
            _inputController = _playerFacade.Input;
        }

        private void Start()
        {
            enabled = Object.HasInputAuthority;
        }

        public void Update()
        {
            if (_inputController.NetworkInput.ShowUI)
            {
                ServiceLocator.Get<PlayerUIService>().ShowMenu(_playerFacade);
            }
            else
            {
                ServiceLocator.Get<PlayerUIService>().HideMenu();
            }
        }
    }
}