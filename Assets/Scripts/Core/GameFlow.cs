using System;
using AFootball.Core.Interfaces;
using AFootball.Core.UI;
using AFootball.Environment;
using UnityEngine;

namespace AFootball.Core
{
    public class GameFlow : MonoBehaviour
    {
        [SerializeField] private Field _field;
        [SerializeField] private HUD _hud;

        private IStateHandler _stateHandler;

        private void Awake()
        {
            _stateHandler = new StateHandler();
            _stateHandler.SetStateChangeCallback(OnGameEvents);
        }

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            _field.Init(_stateHandler);
            _hud.Init(_stateHandler);
            _stateHandler.SetGameState(GameStates.GameStart);
        }

        void OnGameEvents(GameStates state)
        {
            switch (state)
            {
                case GameStates.GameStart:
                case GameStates.Paused:
                case GameStates.GameOver:
                case GameStates.Victory:
                    Time.timeScale = 0;
                    break;
                case GameStates.Running:
                    Time.timeScale = 1;
                    _field.Respawn();
                    break;
            }
        }

        private void OnDestroy()
        {
            _stateHandler.ClearStateChangeCallback();
        }
    }
}