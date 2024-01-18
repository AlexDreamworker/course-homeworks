using Homework1.Task4;

public class GameMode
{
    public IVictoryCondition VictoryCondition { get; private set; }

    public void SetVictoryCondition(IVictoryCondition victoryCondition) 
    {
        VictoryCondition = victoryCondition;
    }
}