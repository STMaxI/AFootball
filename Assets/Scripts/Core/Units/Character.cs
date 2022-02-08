using AFootball.Core.Behavior;
using AFootball.Core.Input;
using AFootball.Core.Interfaces;
using AFootball.Core.Scriptables;
using UnityEngine;

namespace AFootball.Core.Units
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class Character : MonoBehaviour
    {
        private CharacterSettings _characterSettings;

        private IInput _input;
        private Movement _movement;

        protected IStateHandler _stateHandler;

        private void Update()
        {
            _input.ReadInput();
            _movement.Tick();
        }

        public void Init(CharacterSettings characterSettings, Rigidbody playerRb)
        {
            Rigidbody _rigidbody;

            if (!TryGetComponent(out _rigidbody))
                Debug.LogError($"Init: Rigidbody of Character is not found for {characterSettings.Type}");

            _characterSettings = characterSettings;
            _input = _characterSettings.Type == CharacterType.Player
                ? new PlayerInput() as IInput
                : new AIInput();
            _movement = _characterSettings.Type == CharacterType.Player
                ? new PlayerMovement(_input, _rigidbody, _characterSettings) as Movement
                : new RivalMovement(_input, _rigidbody, _characterSettings, playerRb);

            transform.localScale = Vector3.one * _characterSettings.Size;
        }

        public void SetStateHandler(IStateHandler stateHandler)
        {
            _stateHandler = stateHandler;
        }
    }
}