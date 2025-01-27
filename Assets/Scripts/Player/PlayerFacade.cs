﻿using Fusion;
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
        [field: SerializeField] public PlayerHealthController Health { get; private set; }
        [field: SerializeField] public PlayerCameraController Camera { get; private set; }
        [field: SerializeField] public Transform Head { get; private set; }
        [field: SerializeField] public PlayerScoreController Score { get; private set; }

        private IPlayersService PlayersService => ServiceLocator.Get<IPlayersService>();

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