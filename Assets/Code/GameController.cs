using UnityEngine;
using System;
using UnityEngine.UI;

namespace RollTheBall
{
    internal sealed class GameController : MonoBehaviour, IDisposable
    {
        private readonly Text _gameEndingLabel;
        private readonly Text _notificationLabel;
        private readonly Text _tokensLabel;
        private UserInterface _ui;
        private readonly PlayerStats _stats;
        private Hole[] _holes;
        private Bonus[] _bonuses;
        private AudioManager _audioManager;
        private void Awake()
        {
            _audioManager = new AudioManager();

            _ui = new UserInterface(_gameEndingLabel, _notificationLabel, _tokensLabel);
            _stats.PlayerDeath += _ui.Lose;
            _stats.PlayerDeath += PauseGame;
            _stats.PlayerDeath += _audioManager.PlayDefeatSound;

            _holes = FindObjectsOfType<Hole>();
            foreach (Hole h in _holes)
            {
                h.PlayerDeath += _ui.Lose;
                h.PlayerDeath += PauseGame;
                h.PlayerDeath += _audioManager.PlayDefeatSound;
            }

            _bonuses = FindObjectsOfType<Bonus>();
            foreach (Bonus b in _bonuses)
            {
                b.BonusFound += _audioManager.PlayBonusSound;
                b.BonusFound += _ui.DisplayTokens;
            }
        }
        private void PauseGame()
        {
            Time.timeScale = 0.0f;
        }
        public void Dispose()
        {
            _stats.PlayerDeath -= _ui.Lose;
            _stats.PlayerDeath -= PauseGame;
            _stats.PlayerDeath -= _audioManager.PlayDefeatSound;

            foreach (Hole h in _holes)
            {
                h.PlayerDeath -= _ui.Lose;
                h.PlayerDeath -= PauseGame;
                h.PlayerDeath -= _audioManager.PlayDefeatSound;
            }

            foreach (Bonus b in _bonuses)
            {
                b.BonusFound -= _audioManager.PlayBonusSound;
                b.BonusFound -= _ui.DisplayTokens;
            }
        }
    }
}
