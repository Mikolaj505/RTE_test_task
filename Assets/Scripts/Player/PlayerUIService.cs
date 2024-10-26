using MKubiak.Services;
using UnityEngine;

namespace MKubiak.RTETestTask.PlayerUI
{
    public class PlayerUIService : MonoBehaviour
    {
        [SerializeField] private PlayerMenuController _playerMenu;

        private void OnEnable()
        {
            ServiceLocator.Register<PlayerUIService>(this);
        }

        private void OnDisable()
        {
            ServiceLocator.Unregister<PlayerUIService>();
        }

        /// <param name="player"> 
        /// Player for which menu shall show data.
        /// </param>
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