using deVoid.Utils;

namespace MKubiak.RTETestTask
{
    /// <summary>
    /// WARNING: For now, the rest of the game prefers this signal to only be called from FixedNetworkUpdate.
    /// </summary>
    public class PlayerKilledSignal : ASignal<PlayerKilledSignalPayload>
    {
    }
}