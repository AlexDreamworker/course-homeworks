using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace Homework3.Task4
{
    public class SpawnedEnemiesList
    {
        private List<Enemy> _spawnedEnemies = new List<Enemy>();
        
        public void Add(Enemy enemy) => _spawnedEnemies.Add(enemy);

        public void Remove(Enemy enemy) => _spawnedEnemies.Remove(enemy);

        public Enemy GetRandom()
        {
            if (_spawnedEnemies.Count == 0)
                return null;
            else
                return _spawnedEnemies[Random.Range(0, _spawnedEnemies.Count)];
        }
    }
}