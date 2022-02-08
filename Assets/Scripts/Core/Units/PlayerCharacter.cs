using System;
using AFootball.Core.Interfaces;
using AFootball.Core.ObjectTags;
using UnityEngine;

namespace AFootball.Core.Units
{
    public class PlayerCharacter : Character
    {
        private void OnCollisionEnter(Collision other)
        {
            TouchDownArea tdArea;
            if (! other.collider.TryGetComponent(out tdArea))
                return;
            _stateHandler.SetGameState(GameStates.Victory);
        }
    }
}