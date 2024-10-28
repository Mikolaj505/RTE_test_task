using Fusion;
using MKubiak.Services;
using System.Collections.Generic;
using UnityEngine;

namespace MKubiak.RTETestTask
{
    public class PlayerSpawnerService : MonoBehaviour, IPlayerSpawnerService
    {
        [SerializeField] private List<Transform> _spawnPoints = new();
        [SerializeField] private NetworkPrefabRef _playerPrefab;

        private void OnEnable()
        {
            ServiceLocator.Register<IPlayerSpawnerService>(this);
        }

        private void OnDisable()
        {
            ServiceLocator.Unregister<IPlayerSpawnerService>();
        }

        public void SpawnPlayer(NetworkRunner runner, PlayerRef player)
        {
            var spawnPoint = GetMostAlienatedSpawnPoint();

            runner.Spawn(_playerPrefab, spawnPoint.position, spawnPoint.rotation, player);
        }

        private Transform GetMostAlienatedSpawnPoint()
        {
            var players = ServiceLocator.Get<IPlayersService>().GetPlayers();
            Transform furthestSpawnPoint = null;
            float maxDistance = float.MinValue;

            foreach (var spawnPoint in _spawnPoints)
            {
                float minDistanceToAnyPlayer = float.MaxValue;

                // Calculate distance from this spawn point to all active players
                foreach (var activePlayer in players)
                {
                    // Assuming each player has a Player component with a transform
                    float distance = Vector3.SqrMagnitude(activePlayer.transform.position - spawnPoint.position);
                    minDistanceToAnyPlayer = Mathf.Min(minDistanceToAnyPlayer, distance);
                }

                // Find the spawn point with the largest minimum distance to any player
                if (minDistanceToAnyPlayer > maxDistance)
                {
                    maxDistance = minDistanceToAnyPlayer;
                    furthestSpawnPoint = spawnPoint;
                }
            }

            return furthestSpawnPoint;
        }
    }
}
