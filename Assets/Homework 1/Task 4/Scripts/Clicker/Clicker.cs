using UnityEngine;

namespace Homework1.Task4 
{
    public class Clicker : MonoBehaviour
    {
        private Camera _camera;
        private InputReader _inputReader;

        private Ray Ray => _camera.ScreenPointToRay(Input.mousePosition);

        public void Initialize(InputReader inputReader) 
        {
            _inputReader = inputReader;

            _inputReader.MouseClicked += OnMouseClicked;
        }

        private void Awake() => _camera = Camera.main;

        private void OnDisable()
        {
            _inputReader.MouseClicked -= OnMouseClicked;
        }

        private void OnMouseClicked()
        {
            if (Physics.Raycast(Ray, out RaycastHit hit))
                if (hit.collider.TryGetComponent(out Ball ball)) 
                    ball.Deactivate();
        }
    }
}