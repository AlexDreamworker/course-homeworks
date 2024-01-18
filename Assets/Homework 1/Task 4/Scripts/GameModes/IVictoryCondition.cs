using System.Collections.Generic;

namespace Homework1.Task4 
{
    public interface IVictoryCondition
    {
        bool CheckCondition(List<Ball> balls);
    }
}