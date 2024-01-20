using System.Collections.Generic;

namespace Homework1.Task4 
{
    public class ConditionSwitcher
    {
        private Level _level;
        private List<Ball> _balls;

        public ConditionSwitcher(Level level, List<Ball> balls)
        {
            _level = level;
            _balls = balls;
        }

        public void SetDestroyAll() 
        {
            _level.SetVictoryCondition(new DestroyAll(_balls));
        }

        public void SetDestroyConcreteColor(ColorType colorType) 
        {
            _level.SetVictoryCondition(new DestroyConcreteColor(_balls, colorType));
        }
    }
}