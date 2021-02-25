using UnityEngine.UI;

namespace RollTheBall
{
    internal sealed class UserInterface
    {
        private readonly Text _gameEndingLabel;
        private readonly Text _notificationLabel;
        private readonly Text _tokensLabel;
        public UserInterface(Text geLabel, Text notificationLabel, Text tokensLabel)
        {
            _gameEndingLabel = geLabel;
            _gameEndingLabel.text = string.Empty;
            _notificationLabel = notificationLabel;
            _notificationLabel.text = string.Empty;
            _tokensLabel = tokensLabel;
            _tokensLabel.text = string.Empty;
        }
        public void Win()
        {
            _gameEndingLabel.text = "�����������, �� ��������!";
        }
        public void Lose()
        {
            _gameEndingLabel.text = "�� ���������...";
        }
        public void DemandTokens()
        {
            _notificationLabel.text = "��� ������ ����� ������� 50 �������!";
        }
        public void DisplayTokens(int value)
        {
            _tokensLabel.text = value.ToString();
        }
    }

}