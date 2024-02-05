namespace Homework3.Task5
{
    public class HolyLightStats : StatsDecorator
    {
        private const float MULTIPLIER = 2;

        public HolyLightStats(IStatsProvider wrappedEntity) : base(wrappedEntity) { }

        protected override PlayerStats GetStatsInternal()
        {
            return _wrappedEntity.GetStats() * MULTIPLIER;
        }
    }
}