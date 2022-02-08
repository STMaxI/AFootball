using System;
using UnityEngine.Events;
using AFootball.Core.Interfaces;
using UnityEngine;

namespace AFootball.Core
{
    public class StateHandler : IStateHandler
    {
        private GameStates _currentGameState = GameStates.GameStart;
        private Action<GameStates> _callback;


        public void SetGameState(GameStates state)
        {
            _currentGameState = state;
            _callback(_currentGameState);
        }

        public GameStates GetCurrentGameState => _currentGameState;

        public GameStates SetStateChangeCallback(Action<GameStates> callback)
        {
            _callback += callback;
            return _currentGameState;
        }


        public void ClearStateChangeCallback()
        {
            _callback = delegate(GameStates states) {  };
        }

        public void RemoveStateChangeCallback(Action<GameStates> callback) => _callback -= callback;
    }
}