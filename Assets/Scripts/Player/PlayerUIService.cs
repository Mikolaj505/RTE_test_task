using MKubiak.Services;
using UnityEngine;

namespace MKubiak.RTETestTask.PlayerUI
{
    public class PlayerUIService : MonoBehaviour, IPlayerUIService
    {
        [SerializeField] private PlayerMenuController _playerMenu;

        private void OnEnable()
        {
            ServiceLocator.Register<IPlayerUIService>(this);
        }

        private void OnDisable()
        {
            ServiceLocator.Unregister<IPlayerUIService>();
        }

        public void ShowMenu(PlayerFacade player)
        {
            _playerMenu.SetPlayer(player);
            _playerMenu.gameObject.SetActive(true);
        }

        public void HideMenu()
        {
            _playerMenu.gameObject.SetActive(false);
        }
    }
}