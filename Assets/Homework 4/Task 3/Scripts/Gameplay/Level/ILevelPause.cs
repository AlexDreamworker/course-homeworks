using System;

namespace Homework4.Task3
{
    public interface ILevelPause
    {
        event Action<bool> PauseStateChanged;
    }
}