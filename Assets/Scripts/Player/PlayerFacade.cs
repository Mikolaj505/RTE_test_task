using Fusion;
using Fusion.Addons.KCC;
using MKubiak.RTETestTask.Input;
using MKubiak.Services;
using UnityEngine;

namespace MKubiak.RTETestTask
{
    public class PlayerFacade : NetworkBehaviour
    {
        [field: SerializeField] public KCC Motor { get; private set; }
        [field: SerializeField] public PlayerInputController Input { get; private set; }
        [field: SerializeField] public PlayerWeaponsController Weapons { get; private set; }

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