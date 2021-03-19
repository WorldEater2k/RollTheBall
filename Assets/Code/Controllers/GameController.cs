using UnityEngine;
using System;
using UnityEngine.UI;

namespace RollTheBall
{
    internal sealed class GameController : MonoBehaviour, IDisposable
    {
        private UserInterface _ui;
        private PlayerStats _stats;
        private Hole[] _holes;
        private Bonus[] _bonuses;
        private Canvas _canvas;
        private AudioPlayer _audioManager;
        private Initializator _initializator;
        private UpdateController _updateController;
        private InputController _inputController;
        private void Awake()
        {
            _audioManager = new AudioPlayer();
            _canvas = References.Canvas;
            _stats = References.PlayerStats;

            _initializator = References.Initializator;
            _updateController = References.UpdateController;
            _inputController = new InputController(_initializator, _updateController);
            _initializator.InitializeAll();

            Text geLabel = Instantiate(Resources.Load<Text>("UI/EndGame"), _canvas.transform);
            Text notificationLabel = Instantiate(Resources.Load<Text>("UI/Notifications"), _canvas.transform);
            Text tokensLabel = Instantiate(Resources.Load<Text>("UI/Tokens"), _canvas.transform);
            Button restartButton = Instantiate(Resources.Load<Button>("UI/Restart"), _canvas.transform);
            _ui = new UserInterface(geLabel, notificationLabel, tokensLabel, restartButton);

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
        private void Update()
        {
            _updateController.UpdateAll();
        }
        private void OnDestroy()
        {
            Dispose();
        }
        private void PauseGame()
        {
            Time.timeScale = 0.0f;
        }
        public void Dispose()
        {
            _inputController.Dispose();

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
