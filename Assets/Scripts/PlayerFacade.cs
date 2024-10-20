using Fusion;
using MKubiak.Services;

namespace MKubiak.RTETestTask
{
    public class PlayerFacade : NetworkBehaviour
    {
        private PlayersService PlayersService => ServiceLocator.Get<PlayersService>();

        public override void Spawned()
        {
            base.Spawned();

            PlayersService.RegisterPlayer(this);
        }

        public override void Despawned(NetworkRunner runner, bool hasState)
        {
            base.Despawned(runner, hasState);

            PlayersService.UnregisterPlayer(this);
        }
    }
}