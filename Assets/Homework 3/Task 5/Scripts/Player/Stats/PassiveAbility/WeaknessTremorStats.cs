namespace Homework3.Task5
{
    public class WeaknessTremorStats : StatsDecorator
    {
        private const float MULTIPLIER = 0.9f;

        public WeaknessTremorStats(IStatsProvider wrappedEntity) : base(wrappedEntity) { }

        protected override PlayerStats GetStatsInternal()
        {
            var result = _wrappedEntity.GetStats();
            result.Strength *= MULTIPLIER;
            return result;
        }
    }
}