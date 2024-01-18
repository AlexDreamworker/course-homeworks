using UnityEngine;

namespace Homework1.Task4 
{
    public class Player : MonoBehaviour
    {
        private Camera _camera;

        private Ray Ray => _camera.ScreenPointToRay(Input.mousePosition);

        private void Awake() => _camera = Camera.main;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0)) 
                if (Physics.Raycast(Ray, out RaycastHit hit))
                    if (hit.collider.TryGetComponent(out Ball ball)) 
                        ball.Deactivate();
        }
    }
}