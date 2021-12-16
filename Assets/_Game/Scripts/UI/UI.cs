using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    public class UI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _healthText;
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TextMeshProUGUI _timerText;
        [SerializeField] private TextMeshProUGUI _laserText;

        public void OnHealthChanged(int health)
        {
            SetHealthText( health );
        }

        private void SetHealthText(int health)
        {
            _healthText.text = $"Health: {health}";
        }

        private void SetScoreText(string text)
        {
            _scoreText.text = text;
        }

        private void SetTimerText(string text)
        {
            _timerText.text = text;
        }

        private void SetLaserText(string text)
        {
            _laserText.text = text;
        }
    }
}
