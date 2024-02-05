namespace Homework3.Task5
{
    public class CrippleIntelligenceStats : StatsDecorator
    {
        public CrippleIntelligenceStats(IStatsProvider wrappedEntity) : base(wrappedEntity) { }

        protected override PlayerStats GetStatsInternal()
        {
            var result = _wrappedEntity.GetStats();
            result.Intelligence = 0;
            return result;
        }
    }
}