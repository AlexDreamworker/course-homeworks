using System;
using UnityEngine;
using UnityEngine.UI;

namespace Homework4.Task3
{
    [RequireComponent(typeof(Button))]
    public class LevelSelectionButton : MonoBehaviour
    {
        public event Action<GameModeType> Click; 

        [SerializeField] private GameModeType _gameMode;

        private Button _button;

        private void Awake() => _button = GetComponent<Button>();

        private void OnEnable() => _button.onClick.AddListener(OnClick);

        private void OnDisable() => _button.onClick.RemoveListener(OnClick);

        private void OnClick() => Click?.Invoke(_gameMode);
    }
}