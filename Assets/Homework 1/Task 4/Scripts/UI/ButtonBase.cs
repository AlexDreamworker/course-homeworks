using System;
using UnityEngine;
using UnityEngine.UI;

namespace Homework1.Task4 
{
    [RequireComponent(typeof(Button))]
    public abstract class ButtonBase : MonoBehaviour
    {
        protected UI _ui;
        protected Example _example;
        
        protected bool _isInit = false;

        private Button _button;

        public void Initialize(UI ui, Example example) 
        {
            _ui = ui;
            _example = example;

            _isInit = true;
        }

        private void Awake() => _button = GetComponent<Button>();

        private void OnEnable() => _button.onClick.AddListener(ButtonCallback);

        private void OnDisable() => _button.onClick.RemoveListener(ButtonCallback);

        protected virtual void ButtonCallback() 
        {
            if (_isInit == false)
                throw new InvalidOperationException(nameof(_isInit));
        }
    }
}