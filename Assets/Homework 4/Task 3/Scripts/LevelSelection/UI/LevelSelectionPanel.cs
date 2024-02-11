using UnityEngine;
using Zenject;

namespace Homework4.Task3
{
    public class LevelSelectionPanel : MonoBehaviour
    {
        [SerializeField] private LevelSelectionButton[] _levelSelectionButtons;

        private SceneLoadMediator _sceneLoader;

        [Inject]
        private void Construct(SceneLoadMediator sceneLoadMediator)
            => _sceneLoader = sceneLoadMediator;

        private void OnEnable()
        {
            foreach (var levelSelectionButton in _levelSelectionButtons)
                levelSelectionButton.Click += OnLevelSelected;
        }

        private void OnDisable()
        {
            foreach (var levelSelectionButton in _levelSelectionButtons)
                levelSelectionButton.Click -= OnLevelSelected;
        }

        private void OnLevelSelected(GameModeType gameModeType)
            => _sceneLoader.GoToGameplayLevel(new LevelLoadingData(gameModeType));
    }
}