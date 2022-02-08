using AFootball.Core.Input;
using AFootball.Core.Interfaces;
using AFootball.Core.Scriptables;
using UnityEngine;

namespace AFootball.Core.Behavior
{
    public abstract class Movement : ITick
    {
        protected readonly IInput _characterInput;
        protected readonly Rigidbody _rigidbodyToMove;
        protected readonly CharacterSettings _settings;

        protected Movement(IInput characterInput, Rigidbody rigidbodyToMove, CharacterSettings settings)
        {
            _characterInput = characterInput;
            _rigidbodyToMove = rigidbodyToMove;
            _settings = settings;
        }

        public abstract void Tick();
    }
}