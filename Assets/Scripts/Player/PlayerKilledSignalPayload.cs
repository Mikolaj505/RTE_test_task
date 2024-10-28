using Fusion;

namespace MKubiak.RTETestTask
{
    public class PlayerKilledSignalPayload
    {
        public PlayerRef Killer;
        public PlayerRef Victim;

        public PlayerKilledSignalPayload(PlayerRef killer, PlayerRef victim)
        {
            Killer = killer;
            Victim = victim;
        }
    }
}