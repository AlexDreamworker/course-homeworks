using UnityEngine;

namespace Homework1.Task2 
{
    public class Shooter : MonoBehaviour
    {
        private InputReader _inputReader;
        private Weapon _weapon;

        public void Initialize(InputReader inputReader)
        {
            _inputReader = inputReader;

            _inputReader.ShootButtonChanged += OnShootButtonChanged;
        }

        private void OnDisable()
        {
            _inputReader.ShootButtonChanged -= OnShootButtonChanged;
        }

        public void SetWeapon(Weapon weapon) 
        {
            _weapon?.Deactivate();
            _weapon = weapon;
            _weapon.Activate();

            if (_weapon.IsCanShoot == false)
                Debug.Log("This weapon can't shoot, ammo is empty");
        }

        public void OnShootButtonChanged()
        {
            if (_weapon.IsCanShoot == false)
            {
                Debug.Log("I can't shoot, ammo is empty...");
                return;
            }

            _weapon.Fire();
        }
    }
}