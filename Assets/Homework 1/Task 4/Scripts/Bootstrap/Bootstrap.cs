using System.Collections.Generic;
using UnityEngine;

namespace Homework1.Task4
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Clicker _clicker;
        [SerializeField] private UI _ui;

        [Space]
        [SerializeField] private List<Ball> _balls = new List<Ball>();

        private InputReader _inputReader;
        private Level _level;
        private ConditionSwitcher _conditionSwitcher;

        private void Awake() 
        {
            _inputReader = new InputReader();
            _clicker.Initialize(_inputReader);
            _level = new Level();
            _conditionSwitcher = new ConditionSwitcher(_level, _balls);
            _ui.Initialize(_conditionSwitcher);

            Debug.Log("Game Mode is: Destroy All!");
        }

        private void Update() => _inputReader.UpdateUserInput();

        private void OnDisable() => _level.Dispose();
    }
}