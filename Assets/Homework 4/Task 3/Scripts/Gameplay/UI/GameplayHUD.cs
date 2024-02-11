using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Homework4.Task3
{
    public class GameplayHUD : MonoBehaviour
    {
        [SerializeField] private Text _infoText;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _mainMenuButton;

        private SceneLoadMediator _sceneLoadMediator;
        private GameplayHUDMediator _gameplayHUDMediator;

        private readonly string _completedText = "LEVEL COMPLETED";
        private readonly string _failedText = "LEVEL FAILED";

        [Inject]
        private void Construct(SceneLoadMediator sceneLoadMediator, GameplayHUDMediator gameplayHUDMediator)
        {
            _sceneLoadMediator = sceneLoadMediator;
            _gameplayHUDMediator = gameplayHUDMediator;
        }

        private void OnEnable()
        {
            _mainMenuButton.onClick.AddListener(OnMainMenuClick);
            _restartButton.onClick.AddListener(OnRestartClick);
        }

        private void OnDisable()
        {
            _mainMenuButton.onClick.RemoveListener(OnMainMenuClick);
            _restartButton.onClick.RemoveListener(OnRestartClick);
        }

        public void ShowWin()
        {
            gameObject.SetActive(true);

            _infoText.text = _completedText;
            _infoText.color = Color.green;
        }

        public void ShowLose()
        {
            gameObject.SetActive(true);

            _infoText.text = _failedText;
            _infoText.color = Color.red;
        }
        
        public void Hide() => gameObject.SetActive(false);

        private void OnMainMenuClick() => _sceneLoadMediator.GoToLevelSelection();

        private void OnRestartClick()
        {
            _gameplayHUDMediator.RestartLevel();
            
            Hide();
        }
    }
}