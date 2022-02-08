using System;

namespace AFootball.Core.Interfaces
{
    public interface IStateHandler
    {
        public void SetGameState(GameStates state);
        public GameStates GetCurrentGameState { get; }

        public GameStates SetStateChangeCallback(Action<GameStates> callback);
        public void RemoveStateChangeCallback(Action<GameStates> callback);
        public void ClearStateChangeCallback();
    }

    public enum GameStates
    {
        Running,
        GameOver,
        Victory,
        Paused,
        GameStart
    }
}