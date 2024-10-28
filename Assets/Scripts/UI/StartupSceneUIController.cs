using Fusion;
using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;

namespace MKubiak.RTETestTask.GameStartup
{
    public class StartupSceneUIController : MonoBehaviour
    {
        [SerializeField] private List<int> _scenesToLoadAtGameplayStart = new();

        private GameStarter _gameStarter = new();

        [UsedImplicitly]
        public void OnHostStartButton()
        {
            _gameStarter.StartGame(new GameStartInfo(_scenesToLoadAtGameplayStart.ToArray(), GameMode.Host));
        }

        [UsedImplicitly]
        public void OnClientStartButton()
        {
            _gameStarter.StartGame(new GameStartInfo(_scenesToLoadAtGameplayStart.ToArray(), GameMode.Client));
        }
    }
}