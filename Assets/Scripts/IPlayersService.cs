using Fusion;
using System.Collections.Generic;

namespace MKubiak.RTETestTask
{
    public interface IPlayersService
    {
        void RegisterPlayer(PlayerFacade player);
        void UnregisterPlayer(PlayerFacade player);
        PlayerFacade GetPlayer(PlayerRef playerRef);
        IEnumerable<PlayerFacade> GetPlayers();
    }
}
