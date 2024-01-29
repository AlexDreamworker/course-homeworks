using UnityEngine;

namespace Homework2.Task4
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private HUDPanel _hudPanel;
        [SerializeField] private PlayerConfig _playerConfig;
        
        private InputReader _inputReader;
        private Player _player;
        private HUDMediator _hudMediator;

        private void Awake()
        {
            _inputReader = new InputReader();
            _player = new Player(_inputReader, _playerConfig);
            _hudMediator = new HUDMediator(_hudPanel, _player);

            _hudPanel.Initialize(_hudMediator);

            _player.Start();
        }

        private void Update() => _inputReader.UpdateUserInput();

        private void OnDisable()
        {
            _player.Dispose();
            _hudMediator.Dispose();
        }
    }
}