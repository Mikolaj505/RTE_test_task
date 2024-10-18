using Fusion;
using MKubiak.Services;

namespace MKubiak.RTETestTask.GameStartup
{
    public class GameStarter
    {
        public async void StartGame(GameStartInfo gameStartInfo)
        {
            var networkRunner = ServiceLocator.Get<NetworkRunnerService>().CreateNetworkRunner();
            networkRunner.ProvideInput = true;
            var sceneRef = SceneRef.FromIndex(gameStartInfo.SceneIndex);

            await networkRunner.StartGame(new StartGameArgs()
            {
                GameMode = gameStartInfo.Mode,
                SessionName = "TestRoom",
                Scene = sceneRef,
                SceneManager = ServiceLocator.Get<NetworkSceneManagerService>().NetworkSceneManager,
            });
        }
    }
}
