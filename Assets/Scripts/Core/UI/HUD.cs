using System;
using AFootball.Core.Interfaces;
using UnityEngine;

namespace AFootball.Core.UI
{
    public class HUD: MonoBehaviour, IHUDActionCallbacks
    {
        [SerializeField] private Popup gameStartPopup;
        [SerializeField] private Popup gameOverPopup;
        [SerializeField] private Popup victoryPopup;

        private IStateHandler _stateHandler;

        public void SetGameStateHandler(IStateHandler stateHandler) => _stateHandler = stateHandler;

        public void Init(IStateHandler stateHandler)
        {
            _stateHandler = stateHandler;
            _stateHandler.SetStateChangeCallback(OnGameEvents);
            gameStartPopup.Init(this);
            gameOverPopup.Init(this);
            victoryPopup.Init(this);
        }

        private void OnGameEvents(GameStates gameStates)
        {
            switch (gameStates)
            {
                case GameStates.GameStart:
                    gameStartPopup.ShowPopup();
                    break;
                case GameStates.GameOver:
                    gameOverPopup.ShowPopup();
                    break;
                case GameStates.Victory:
                    victoryPopup.ShowPopup();
                    break;
            }
        }
        
        public void OnGameOverPopupClose() => _stateHandler.SetGameState(GameStates.Running);

        public void OnStartPopupClose() => _stateHandler.SetGameState(GameStates.Running);

        public void OnVictoryPopupClose() => _stateHandler.SetGameState(GameStates.Running);

        private void OnDestroy() => _stateHandler.RemoveStateChangeCallback(OnGameEvents);
    }
}