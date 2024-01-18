using UnityEngine;

namespace Homework1.Task4 
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private ColorType _colorType;

        public ColorType ColorType => _colorType;
        public bool IsActive { get; private set; }

        private void Start() => Activate();

        public void Activate()
        {
            IsActive = true;
            gameObject.SetActive(true);
        }
        
        public void Deactivate()
        {
            IsActive = false;
            gameObject.SetActive(false);
        }
    }
}