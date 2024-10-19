using MKubiak.Services;
using System.Collections.Generic;
using UnityEngine;

namespace MKubiak.RTETestTask
{
    public class PlayersService : MonoBehaviour
    {
        public List<PlayerFacade> Players { get; private set; } = new();

        private void OnEnable()
        {
            ServiceLocator.Register<PlayersService>(this);
        }

        private void OnDisable()
        {
            ServiceLocator.Unregister<PlayersService>();
        }

        public void RegisterPlayer(PlayerFacade player)
        {
            Players.Add(player);
        }

        public void UnregisterPlayer(PlayerFacade player)
        {
            Players.Remove(player);
        }
    }
}
