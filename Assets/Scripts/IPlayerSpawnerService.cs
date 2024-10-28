using Fusion;

namespace MKubiak.RTETestTask
{
    public interface IPlayerSpawnerService
    {
        void SpawnPlayer(NetworkRunner runner, PlayerRef player);
    }
}
