using System;
using System.Collections.Generic;

namespace Homework3.Task5
{
    public class SpecializationStats : StatsDecorator
    {
        private readonly SpecializationType _specialization;

        private readonly SpecializationConfig _config;

        public SpecializationStats(IStatsProvider wrappedEntity, SpecializationType specialization) : base(wrappedEntity)
        {
            _specialization = specialization;

            _config = new SpecializationConfig();
        }

        protected override PlayerStats GetStatsInternal()
        {
            return _wrappedEntity.GetStats() + GetSpecializationStats(_specialization);
        }

        private PlayerStats GetSpecializationStats(SpecializationType specialization)
        {
            switch (specialization) 
            {
                case SpecializationType.Thief:
                    return new PlayerStats() 
                    {
                        Strength = _config.Ork[StatsType.Strength],
                        Agility = _config.Ork[StatsType.Agility],
                        Intelligence = _config.Ork[StatsType.Intelligence]
                    };
                case SpecializationType.Mage:
                    return new PlayerStats() 
                    {
                        Strength = _config.Human[StatsType.Strength],
                        Agility = _config.Human[StatsType.Agility],
                        Intelligence = _config.Human[StatsType.Intelligence]
                    };
                case SpecializationType.Barbarian:
                    return new PlayerStats() 
                    {
                        Strength = _config.Elf[StatsType.Strength],
                        Agility = _config.Elf[StatsType.Agility],
                        Intelligence = _config.Elf[StatsType.Intelligence]
                    };
                default:
                    throw new NotImplementedException($"Unknown race type: {specialization}");
                
            }
        }

        private class SpecializationConfig
        {
            private Dictionary<StatsType, float> _ork;
            public Dictionary<StatsType, float> _human;
            public Dictionary<StatsType, float> _elf;

            public IReadOnlyDictionary<StatsType, float> Ork => _ork;
            public IReadOnlyDictionary<StatsType, float> Human => _human;
            public IReadOnlyDictionary<StatsType, float> Elf => _elf;

            public SpecializationConfig() 
            {
                _ork = new Dictionary<StatsType, float>() 
                {
                    { StatsType.Strength, 0 },
                    { StatsType.Agility, 2 },
                    { StatsType.Intelligence, 0 }
                };

                _human = new Dictionary<StatsType, float>() 
                {
                    { StatsType.Strength, 0 },
                    { StatsType.Agility, 0 },
                    { StatsType.Intelligence, 2 }
                };

                _elf = new Dictionary<StatsType, float>() 
                {
                    { StatsType.Strength, 2 },
                    { StatsType.Agility, 0 },
                    { StatsType.Intelligence, 0 }
                };
            }
        }
    }
}