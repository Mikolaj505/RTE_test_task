using deVoid.Utils;
using Fusion;

namespace MKubiak.RTETestTask
{
    public class PlayerScoreController : NetworkBehaviour
    {
        [Networked] public float Score { get; private set; }

        private void OnEnable()
        {
            Signals.Get<PlayerKilledSignal>().AddListener(OnPlayerKilled);
        }

        private void OnDisable()
        {
            Signals.Get<PlayerKilledSignal>().RemoveListener(OnPlayerKilled);
        }

        private void OnPlayerKilled(PlayerKilledSignalPayload payload)
        {
            if (payload.Killer == Object.InputAuthority)
            {
                Score++;
            }
        }
    }
}