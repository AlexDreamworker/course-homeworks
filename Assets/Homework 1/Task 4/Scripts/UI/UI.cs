using System.Collections.Generic;
using UnityEngine;

namespace Homework1.Task4 
{
    public class UI : MonoBehaviour
    {
        [SerializeField] private Example _example;
        [SerializeField] private TextGameModeInfo _textGameModeInfo;

        [Space]
        [SerializeField] private List<ButtonBase> _buttons = new List<ButtonBase>();

        private void Awake()
        {
            foreach (ButtonBase button in _buttons)
                button.Initialize(this, _example);
        }

        public void ChangeGameModeInfo(string info) 
        {
            _textGameModeInfo.SetText(info);
        }
    }
}