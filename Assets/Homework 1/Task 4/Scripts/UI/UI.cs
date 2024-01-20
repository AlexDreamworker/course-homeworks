using System.Collections.Generic;
using UnityEngine;

namespace Homework1.Task4 
{
    public class UI : MonoBehaviour
    {
        [SerializeField] private TextGameModeInfo _textGameModeInfo;

        [Space]
        [SerializeField] private List<ButtonBase> _buttons = new List<ButtonBase>();

        private ConditionSwitcher _conditionSwitcher;

        public void Initialize(ConditionSwitcher conditionSwitcher) 
        {
            _conditionSwitcher = conditionSwitcher;
        }

        private void Awake()
        {
            foreach (ButtonBase button in _buttons)
                button.Initialize(this, _conditionSwitcher);
        }

        public void ChangeGameModeInfo(string info) 
        {
            _textGameModeInfo.SetText(info);
        }
    }
}