using Fusion;
using MKubiak.Services;
using TMPro;
using UnityEngine;

namespace MKubiak.RTETestTask.PlayerUI
{
    public class PlayerMenuController : MonoBehaviour
    {
        [SerializeField] private string _scoreFormat = "Score: {0}";
        [SerializeField] private TMP_Text _scoreLabel;
        [SerializeField] private PlayerMenuPositioner _positioner;

        private PlayerFacade _player;

        private void OnEnable()
        {
            RefreshPlayerMenu();
            _positioner.Position(_player);
        }

        public void SetPlayer(PlayerFacade player)
        {
            _player = player;
        }

        public void RefreshPlayerMenu()
        {
            float score = 0f;
            if (ServiceLocator.Get<IMatchService>().TryGetPlayerStatistics(_player?.Object.InputAuthority ?? PlayerRef.None, out PlayerStatistics playerStatistics))
            {
                score = playerStatistics.Score;
            }

            _scoreLabel.text = string.Format(_scoreFormat, score);
        }
    }
}