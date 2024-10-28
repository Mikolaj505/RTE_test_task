using deVoid.Utils;
using Fusion;
using MKubiak.Services;
using UnityEngine;

namespace MKubiak.RTETestTask
{
    public class PlayerHealthController : NetworkBehaviour
    {
        [field: SerializeField] public float Health { get; private set; }

        /// <summary>
        /// WARNING: TakeDamage should only be called from FixedUpdateNetwork 
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="damageInflictor"></param>
        public void TakeDamage(float amount, PlayerRef damageInflictor)
        {
            if (Runner.IsServer == false)
            {
                return;
            }

            Health -= amount;
            if (Health <= 0)
            {
                Die(damageInflictor);
            }
        }

        private void Die(PlayerRef deathCauser)
        {
            Signals.Get<PlayerKilledSignal>().Dispatch(new PlayerKilledSignalPayload(deathCauser, Object.InputAuthority));

            // For now, immedietly respawn player
            ServiceLocator.Get<PlayerSpawner>().SpawnPlayer(Runner, Object.InputAuthority);
            Runner.Despawn(Object);
        }
    }
}