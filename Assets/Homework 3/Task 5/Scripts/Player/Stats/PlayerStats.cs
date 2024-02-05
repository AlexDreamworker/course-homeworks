namespace Homework3.Task5
{
    public struct PlayerStats
    {
        public float Strength { get; set; }
        public float Agility { get; set; }
        public float Intelligence { get; set; }

        public static PlayerStats operator +(PlayerStats current, PlayerStats addition) 
        {
            return new PlayerStats() 
            {
                Strength = current.Strength + addition.Strength,
                Agility = current.Agility + addition.Agility,
                Intelligence = current.Intelligence + addition.Intelligence
            };
        }
        
        public static PlayerStats operator *(PlayerStats current, float multiplier) 
        {
            return new PlayerStats() 
            {
                Strength = current.Strength * multiplier,
                Agility = current.Agility * multiplier,
                Intelligence = current.Intelligence * multiplier
            };
        }
    }
}