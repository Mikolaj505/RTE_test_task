using Fusion;
using UnityEngine;

namespace MKubiak.RTETestTask.Input
{
    public struct PlayerInput : INetworkInput
    {
        public Vector2 Movement;
        public Vector2 Look;
        public NetworkButtons Actions;

        public bool Interact { get { return Actions.IsSet(PlayerInputAction.Interact); } set { Actions.Set(PlayerInputAction.Interact, value); } }
        public bool Fire { get { return Actions.IsSet(PlayerInputAction.Fire); } set { Actions.Set(PlayerInputAction.Fire, value); } }
    }

    public enum PlayerInputAction
    {
        Interact = 1,
        Fire = 2,
    }
}
