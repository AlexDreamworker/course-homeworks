using System;
using System.Collections.Generic;

namespace Homework3.Task5
{
    public class RaceStats : IStatsProvider
    {
        private readonly RaceType _raceType;

        private readonly RaceConfig _config;

        public RaceStats(RaceType raceType)
        {
            _raceType = raceType;

            _config = new RaceConfig();
        }

        public PlayerStats GetStats()
        {
            switch (_raceType) 
            {
                case RaceType.Ork:
                    return new PlayerStats() 
                    {
                        Strength = _config.Ork[StatsType.Strength],
                        Agility = _config.Ork[StatsType.Agility],
                        Intelligence = _config.Ork[StatsType.Intelligence]
                    };
                case RaceType.Human:
                    return new PlayerStats() 
                    {
                        Strength = _config.Human[StatsType.Strength],
                        Agility = _config.Human[StatsType.Agility],
                        Intelligence = _config.Human[StatsType.Intelligence]
                    };
                case RaceType.Elf:
                    return new PlayerStats() 
                    {
                        Strength = _config.Elf[StatsType.Strength],
                        Agility = _config.Elf[StatsType.Agility],
                        Intelligence = _config.Elf[StatsType.Intelligence]
                    };
                default:
                    throw new NotImplementedException($"Unknown race type {_raceType}");
                
            }
        }

        private class RaceConfig
        {
            private Dictionary<StatsType, float> _ork;
            public Dictionary<StatsType, float> _human;
            public Dictionary<StatsType, float> _elf;

            public IReadOnlyDictionary<StatsType, float> Ork => _ork;
            public IReadOnlyDictionary<StatsType, float> Human => _human;
            public IReadOnlyDictionary<StatsType, float> Elf => _elf;

            public RaceConfig() 
            {
                _ork = new Dictionary<StatsType, float>() 
                {
                    { StatsType.Strength, 10 },
                    { StatsType.Agility, 6 },
                    { StatsType.Intelligence, 4}
                };

                _human = new Dictionary<StatsType, float>() 
                {
                    { StatsType.Strength, 9 },
                    { StatsType.Agility, 5 },
                    { StatsType.Intelligence, 6 }
                };

                _elf = new Dictionary<StatsType, float>() 
                {
                    { StatsType.Strength, 6 },
                    { StatsType.Agility, 7 },
                    { StatsType.Intelligence, 7 }
                };
            }
        }
    }
}