using Fusion;
using MKubiak.Services;
using UnityEngine.SceneManagement;

namespace MKubiak.RTETestTask.GameStartup
{
    public class GameStarter
    {
        public async void StartGame(GameStartInfo gameStartInfo)
        {
            var networkRunner = ServiceLocator.Get<INetworkRunnerService>().CreateNetworkRunner();
            var sceneManager = ServiceLocator.Get<INetworkSceneService>().GetNetworkSceneManager();
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
                var menuSceneRef = SceneRef.FromIndex(1);
                sceneManager.UnloadScene(menuSceneRef);

                if (runner.IsSceneAuthority)
                {
                    foreach (var sceneIdx in gameStartInfo.GameplaySceneIndexes)
                    {
                        var sceneRef = SceneRef.FromIndex(sceneIdx);
                        runner.LoadScene(sceneRef, LoadSceneMode.Additive);
                    }
                }
            }
        }
    }
}
