using UnityEngine;

namespace Homework3.Task3
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private CoinsSpawner _spawner;

        private void Awake() => _spawner.StartWork();
    }
}