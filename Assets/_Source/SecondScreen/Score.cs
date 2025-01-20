using TMPro;
using UnityEngine;

namespace _Source.SecondScreen
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        private int _score;

        public void AddScore()
        {
            _score++;
            _scoreText.text = _score.ToString();
        }

        public int GetScore()
        {
            return _score;
        }
    }
}