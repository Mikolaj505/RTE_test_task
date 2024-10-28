using Fusion;
using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MKubiak.RTETestTask.GameStartup
{
    public class StartupSceneUIController : MonoBehaviour
    {
        [SerializeField] private Button[] _buttonsToDisableOnGameStart;

        [SerializeField] private List<int> _scenesToLoadAtGameplayStart = new();

        private GameStarter _gameStarter = new();

        [UsedImplicitly]
        public void OnHostStartButton()
        {
            _gameStarter.StartGame(new GameStartInfo(_scenesToLoadAtGameplayStart.ToArray(), GameMode.Host));
            SetButtonsInteractable(false);
        }

        [UsedImplicitly]
        public void OnClientStartButton()
        {
            _gameStarter.StartGame(new GameStartInfo(_scenesToLoadAtGameplayStart.ToArray(), GameMode.Client));
            SetButtonsInteractable(false);
        }

        private void SetButtonsInteractable(bool active)
        {
            foreach (var button in _buttonsToDisableOnGameStart)
            {
                button.interactable = active;
            }
        }
    }
}