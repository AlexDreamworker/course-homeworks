using System.Collections.Generic;
using System.Linq;

namespace Homework1.Task4 
{
    public class DestroyAll : IVictoryCondition
    {
        public bool CheckCondition(List<Ball> balls)
        {
            return balls.All(ball => ball.IsActive == false);
        }
    }
}