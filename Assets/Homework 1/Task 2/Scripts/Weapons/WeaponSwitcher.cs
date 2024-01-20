using System;
using System.Collections.Generic;

namespace Homework1.Task2 
{
    public class WeaponSwitcher : IDisposable
    {
        private Shooter _shooter;
        private InputReader _inputReader;
        private List<Weapon> _weapons;

        private int _weaponIndex = 0;

        public WeaponSwitcher(Shooter shooter, InputReader inputReader, List<Weapon> weapons) 
        {
            _shooter = shooter;
            _inputReader = inputReader;
            _weapons = weapons;

            _inputReader.NextWeaponChanged += OnNextWeaponChanged;
            _inputReader.PreviousWeaponChanged += OnPreviousWeaponChanged;

            _shooter.SetWeapon(_weapons[_weaponIndex]);
        }

        public void Dispose()
        {
            _inputReader.NextWeaponChanged -= OnNextWeaponChanged;
            _inputReader.PreviousWeaponChanged -= OnPreviousWeaponChanged;
        }

        private void OnNextWeaponChanged() 
        {
            _weaponIndex = _weaponIndex >= _weapons.Count - 1 ? 0 : _weaponIndex += 1;
            _shooter.SetWeapon(_weapons[_weaponIndex]);
        }

        private void OnPreviousWeaponChanged() 
        {
            _weaponIndex = _weaponIndex <= 0 ? _weapons.Count - 1 : _weaponIndex -= 1;
            _shooter.SetWeapon(_weapons[_weaponIndex]);
        }
    }
}