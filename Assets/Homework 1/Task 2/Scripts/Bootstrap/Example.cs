using System.Collections.Generic;
using UnityEngine;

namespace Homework1.Task2
{
    public class Example : MonoBehaviour
    {
        [SerializeField] private Player _player;

        [Space]
        [SerializeField] private List<Weapon> _weapons = new List<Weapon>();

        private int _weaponIndex;

        private readonly string _mouseScrollWheelKey = "Mouse ScrollWheel";

        private void Awake()
        {
            _weaponIndex = 0;
            _player.SetWeapon(_weapons[_weaponIndex]);
        }

        private void Update() => UpdateUserInput();

        private void UpdateUserInput() 
        {
            if (Input.GetAxis(_mouseScrollWheelKey) < 0f)
            {
                _weaponIndex = _weaponIndex >= _weapons.Count - 1 ? 0 : _weaponIndex += 1;

                _player.SetWeapon(_weapons[_weaponIndex]);
            }

            if (Input.GetAxis(_mouseScrollWheelKey) > 0f) 
            {
                _weaponIndex = _weaponIndex <= 0 ? _weapons.Count - 1 : _weaponIndex -= 1;

                _player.SetWeapon(_weapons[_weaponIndex]);
            }

            if (Input.GetKeyDown(KeyCode.Mouse0)) 
            {
                _player.Shoot();
            }
        }
    }
}