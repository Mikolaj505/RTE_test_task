using Fusion;

namespace MKubiak.RTETestTask.GameStartup
{
    public class GameStartInfo
    {
        public int[] GameplaySceneIndexes { get; private set; }
        public GameMode Mode { get; private set; }

        public GameStartInfo(int[] sceneIndex, GameMode mode)
        {
            GameplaySceneIndexes = sceneIndex;
            Mode = mode;
        }
    }
}
