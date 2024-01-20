using System.Collections.Generic;
using UnityEngine;

namespace Homework1.Task2
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Shooter _shooter;
        [SerializeField] private List<Weapon> _weapons = new List<Weapon>();

        private InputReader _inputReader;
        private WeaponSwitcher _weaponSwitcher;

        private void Awake()
        {
            _inputReader = new InputReader();
            _weaponSwitcher = new WeaponSwitcher(_shooter, _inputReader, _weapons);
            _shooter.Initialize(_inputReader);
        }

        private void Update() => _inputReader.UpdateUserInput();

        private void OnDisable() => _weaponSwitcher.Dispose();
    }
}