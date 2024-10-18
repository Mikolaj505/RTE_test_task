using Fusion;
using JetBrains.Annotations;
using UnityEngine;

namespace MKubiak.RTETestTask.GameStartup
{
    public class StartupSceneUIController : MonoBehaviour
    {
        [SerializeField] private int _gameplaySceneIndex = 2;

        private GameStarter _gameStarter = new();

        [UsedImplicitly]
        public void OnHostStartButton()
        {
            _gameStarter.StartGame(new GameStartInfo(_gameplaySceneIndex, GameMode.Host));
        }

        [UsedImplicitly]
        public void OnClientStartButton()
        {
            _gameStarter.StartGame(new GameStartInfo(_gameplaySceneIndex, GameMode.Client));
        }
    }
}
