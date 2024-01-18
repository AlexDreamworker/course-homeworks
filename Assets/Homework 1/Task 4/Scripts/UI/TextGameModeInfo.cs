using UnityEngine;
using UnityEngine.UI;

namespace Homework1.Task4 
{
    [RequireComponent(typeof(Text))]
    public class TextGameModeInfo : MonoBehaviour
    {
        private Text _text;

        private void Awake() => _text = GetComponent<Text>();

        public void SetText(string text) => _text.text = text;
    }
}