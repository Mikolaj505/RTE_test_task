using Fusion;

namespace MKubiak.RTETestTask
{
    public class OnPlayerJoinedSignalPayload
    {
        public PlayerRef Player;

        public OnPlayerJoinedSignalPayload(PlayerRef player)
        {
            Player = player;
        }
    }
}
