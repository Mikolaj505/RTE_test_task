using Fusion;
using UnityEngine;

namespace MKubiak.RTETestTask.Weapons
{
    public class SnowballController : NetworkBehaviour
    {
        private enum SnowballState
        {
            None,
            Held,
            Thrown,
            Hit,
        }

        private SnowballState _state;
        private Transform _snowballSocket;

        public override void Spawned()
        {
            _state = SnowballState.Held;
        }

        public void Setup(Transform snowballSocket)
        {
            _snowballSocket = snowballSocket;
        }

        public override void FixedUpdateNetwork()
        {
            switch (_state)
            {
                case SnowballState.None:
                    break;
                case SnowballState.Held:
                    UpdateHeldState();
                    break;
                case SnowballState.Thrown:
                    break;
                case SnowballState.Hit:
                    break;
            }
        }

        public void UpdateHeldState()
        {
            transform.position = _snowballSocket.position;
        }
    }
}