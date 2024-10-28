using deVoid.Utils;
using Fusion;
using MKubiak.Services;

namespace MKubiak.RTETestTask
{
    public class MatchService : NetworkBehaviour
    {
        [Networked][Capacity(32)] private NetworkDictionary<PlayerRef, PlayerStatistics> PlayerRefToPlayerStatistics { get; }

        private void OnEnable()
        {
            ServiceLocator.Register<MatchService>(this);
            Signals.Get<PlayerKilledSignal>().AddListener(OnPlayerKilled);
            Signals.Get<OnPlayerJoinedSignal>().AddListener(OnPlayerJoined);
        }

        private void OnDisable()
        {
            ServiceLocator.Unregister<MatchService>();
            Signals.Get<PlayerKilledSignal>().RemoveListener(OnPlayerKilled);
            Signals.Get<OnPlayerJoinedSignal>().RemoveListener(OnPlayerJoined);
        }

        public void RegisterPlayer(PlayerRef player)
        {
            PlayerRefToPlayerStatistics.Add(player, new PlayerStatistics());
        }

        public void UnregisterPlayer(PlayerRef player)
        {

        }

        private void OnPlayerKilled(PlayerKilledSignalPayload payload)
        {
            if (PlayerRefToPlayerStatistics.TryGet(payload.Killer, out PlayerStatistics killerStatistics))
            {
                killerStatistics.Score++;

                PlayerRefToPlayerStatistics.Set(payload.Killer, killerStatistics);
            }
        }

        private void OnPlayerJoined(OnPlayerJoinedSignalPayload payload)
        {
            RegisterPlayer(payload.Player);
        }

        public bool TryGetPlayerStatistics(PlayerRef player, out PlayerStatistics playerStatistics) => PlayerRefToPlayerStatistics.TryGet(player, out playerStatistics);
    }
}
