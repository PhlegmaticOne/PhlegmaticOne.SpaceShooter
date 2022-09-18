using TMPro;
using UnityEngine;

namespace AssemblyCSharp.Assets.Scripts.UI
{
    public class ScoreUpdate : MonoBehaviour
    {
        private TextMeshProUGUI _text;
        private int _score;
        void Start()
        {
            _text = GetComponent<TextMeshProUGUI>();
            Enemy.Killed += EnemyOnKilled;
            EnemyOnKilled(null, 0);
        }

        private void EnemyOnKilled(object sender, int e)
        {
            _score += e;
            _text.text = _score.ToString();

            if (PlayerPrefs.HasKey("Score") == false)
            {
                PlayerPrefs.SetInt("Score", _score);
            }
            else
            {
                if (PlayerPrefs.GetInt("Score") < _score)
                {
                    PlayerPrefs.SetInt("Score", _score);
                }
            }
        }

        void OnDisable()
        {
            Enemy.Killed -= EnemyOnKilled;
        }
    }
}
