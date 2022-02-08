using System;
using AFootball.Core.Interfaces;
using UnityEngine;

namespace AFootball.Core.Units
{
    public class RivalCharacter : Character
    {
        private void OnCollisionEnter(Collision other)
        {
            PlayerCharacter playerCharacter;
            if (! other.collider.TryGetComponent(out playerCharacter))
                return;
            _stateHandler.SetGameState(GameStates.GameOver);
        }
    }
}