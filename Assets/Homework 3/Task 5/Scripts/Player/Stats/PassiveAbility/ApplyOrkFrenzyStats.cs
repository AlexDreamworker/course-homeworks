namespace Homework3.Task5
{
    public class ApplyOrkFrenzyStats : StatsDecorator
    {
        public ApplyOrkFrenzyStats(IStatsProvider wrappedEntity) : base(wrappedEntity) { }

        protected override PlayerStats GetStatsInternal()
        {
            return _wrappedEntity.GetStats() + new RaceStats(RaceType.Ork).GetStats();
        }
    }
}