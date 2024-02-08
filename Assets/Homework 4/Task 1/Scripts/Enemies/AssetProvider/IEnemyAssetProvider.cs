namespace Homework4.Task1
{
    public interface IEnemyAssetProvider
    {
        EnemyConfig GetConfig(EnemyType enemyType);
    }
}