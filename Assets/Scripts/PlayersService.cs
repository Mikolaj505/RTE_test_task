using Fusion;
using MKubiak.Services;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MKubiak.RTETestTask
{
    public class PlayersService : MonoBehaviour, IPlayersService
    {
        private List<PlayerFacade> Players { get; set; } = new();

        private void OnEnable()
        {
            ServiceLocator.Register<IPlayersService>(this);
        }

        private void OnDisable()
        {
            ServiceLocator.Unregister<IPlayersService>();
        }

        public void RegisterPlayer(PlayerFacade player)
        {
            Players.Add(player);
        }

        public void UnregisterPlayer(PlayerFacade player)
        {
            Players.Remove(player);
        }

        public PlayerFacade GetPlayer(PlayerRef playerRef)
        {
            foreach (var player in Players)
            {
                if (player.Object.InputAuthority == playerRef)
                {
                    return player;
                }
            }
            return null;
        }

        public IEnumerable<PlayerFacade> GetPlayers()
        {
            // Return a copy.
            return Players.ToList();
        }
    }
}
