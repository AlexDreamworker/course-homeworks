using UnityEngine;

namespace Homework3.Task5
{
    public class Bootstrap : MonoBehaviour
    {
        private Player _player;

        private void Awake()
        {
            _player = new Player(PlayerStats());
        }

        private IStatsProvider PlayerStats() 
        {
            IStatsProvider stats = new RaceStats(RaceType.Ork);
            stats = new SpecializationStats(stats, SpecializationType.Mage);
            stats = new HolyLightStats(stats);
            return stats;
        }
    }
}