using UnityEngine;
using Zenject;

namespace Homework4.Task3
{
    public class Clicker : MonoBehaviour
    {
        private Camera _camera;
        private InputReader _inputReader;

        private ILevelPause _levelPause;

        private bool _isPause;

        private Ray Ray => _camera.ScreenPointToRay(Input.mousePosition);

        [Inject]
        private void Construct(InputReader inputReader, ILevelPause pause) 
        {
            _inputReader = inputReader;
            _levelPause = pause;

            _inputReader.MouseClicked += OnMouseClicked;
            _levelPause.PauseStateChanged += OnLevelPaused;
        }

        private void Awake() => _camera = Camera.main;

        private void OnDisable()
        {
            _inputReader.MouseClicked -= OnMouseClicked;
            _levelPause.PauseStateChanged -= OnLevelPaused;
        }

        private void OnMouseClicked()
        {
            if (_isPause)
                return;

            if (Physics.Raycast(Ray, out RaycastHit hit))
                if (hit.collider.TryGetComponent(out Ball ball)) 
                    ball.Deactivate();
        }

        private void OnLevelPaused(bool isPause) => _isPause = isPause;
    }
}