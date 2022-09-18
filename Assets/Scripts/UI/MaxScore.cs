using TMPro;
using UnityEngine;

namespace AssemblyCSharp.Assets.Scripts.UI
{
    public class MaxScore : MonoBehaviour
    {
        private TextMeshProUGUI _text;
        void Start()
        {
            _text = GetComponent<TextMeshProUGUI>();
            _text.text = PlayerPrefs.GetInt("Score", 0).ToString();
        }
    }
}
