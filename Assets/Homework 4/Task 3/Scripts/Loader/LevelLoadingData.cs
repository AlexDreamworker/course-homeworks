namespace Homework4.Task3
{
    public class LevelLoadingData
    {
        private GameModeType _gameModeType;

        public LevelLoadingData(GameModeType gameModeType) 
            => _gameModeType = gameModeType;

        public GameModeType GameModeType => _gameModeType;
    }
}