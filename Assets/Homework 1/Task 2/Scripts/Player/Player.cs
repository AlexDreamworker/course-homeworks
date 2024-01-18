using UnityEngine;

namespace Homework1.Task2 
{
    public class Player : MonoBehaviour
    {
        private Weapon _weapon;

        public void SetWeapon(Weapon weapon) 
        {
            _weapon?.Deactivate();
            _weapon = weapon;
            _weapon.Activate();

            if (IsAmmoEmpty())
                Debug.Log("I can't shoot, ammo is empty...");
        }

        public void Shoot() => _weapon.Fire();

        private bool IsAmmoEmpty() 
        {
            bool result = false;

            if (_weapon is IReloadable)
            {
                IReloadable reloadableWeapon = (IReloadable)_weapon;
                result = reloadableWeapon.IsAmmoEmpty();
            }

            return result;
        }
    }
}