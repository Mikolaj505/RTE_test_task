using Fusion;

namespace MKubiak.RTETestTask
{
    public interface IMatchService
    {
        void RegisterPlayer(PlayerRef player);
        void UnregisterPlayer(PlayerRef player);
        bool TryGetPlayerStatistics(PlayerRef player, out PlayerStatistics playerStatistics);
    }
}
