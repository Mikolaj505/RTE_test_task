using Fusion;
using MKubiak.Services;
using System.Linq;

namespace MKubiak.RTETestTask.GameStartup
{
    public class GameStarter
    {
        public async void StartGame(GameStartInfo gameStartInfo)
        {
            var networkRunner = ServiceLocator.Get<NetworkRunnerService>().CreateNetworkRunner();
            var sceneManager = ServiceLocator.Get<NetworkSceneManagerService>().NetworkSceneManager;
            networkRunner.ProvideInput = true;

            await networkRunner.StartGame(new StartGameArgs()
            {
                GameMode = gameStartInfo.Mode,
                SessionName = "TestRoom",
                SceneManager = sceneManager,
                OnGameStarted = OnGameStarted
            });

            void OnGameStarted(NetworkRunner runner)
            {
                if (runner.IsSceneAuthority)
                {
                    var menuSceneRef = SceneRef.FromIndex(1);
                    sceneManager.UnloadScene(menuSceneRef);

                    foreach (var sceneIdx in gameStartInfo.GameplaySceneIndexes)
                    {
                        var sceneRef = SceneRef.FromIndex(sceneIdx);
                        sceneManager.LoadScene(sceneRef, new NetworkLoadSceneParameters());
                    }
                }
            }
        }
    }
}
