using Fusion;
using MKubiak.Services;
using UnityEngine;

namespace MKubiak.RTETestTask
{
    public class PlayerHealthController : NetworkBehaviour
    {
        [field: SerializeField] public float Health { get; private set; }

        public void TakeDamage(float amount)
        {
            if (Runner.IsServer == false)
            {
                return;
            }

            Health -= amount;
            if (Health <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            // For now, immedietly respawn player
            ServiceLocator.Get<PlayerSpawner>().SpawnPlayer(Runner, Object.InputAuthority);
            Runner.Despawn(Object);
        }
    }
}