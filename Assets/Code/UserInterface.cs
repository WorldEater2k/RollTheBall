using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;

namespace RollTheBall
{
    internal sealed class UserInterface
    {
        private readonly Text _gameEndingLabel;
        private readonly Text _notificationLabel;
        private readonly Text _tokensLabel;
        private readonly Button _restartButton;
        public UserInterface(Text geLabel, Text notificationLabel, Text tokensLabel, Button restartButton)
        {
            _gameEndingLabel = geLabel;
            _notificationLabel = notificationLabel;
            _tokensLabel = tokensLabel;
            _restartButton = restartButton;
            _restartButton.gameObject.SetActive(false);
            _restartButton.onClick.AddListener(RestartGame);
        }
        public void Win()
        {
            _gameEndingLabel.color = Color.green;
            _gameEndingLabel.text = "Поздравляем, вы победили!";
        }
        public void Lose()
        {
            _gameEndingLabel.color = Color.black;
            _gameEndingLabel.text = "Вы проиграли...";
            _restartButton.gameObject.SetActive(true);
        }
        public void DemandTokens()
        {
            _notificationLabel.text = "Для победы нужно собрать 50 токенов!";
            Wait(3f);
            _notificationLabel.text = "";
            
        }
        public void DisplayTokens(int value)
        {
            _tokensLabel.text = (int.Parse(_tokensLabel.text) + value).ToString();
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(0);
        }

        private IEnumerator Wait(float seconds)
        {
            yield return new WaitForSeconds(seconds);
        }
    }

}