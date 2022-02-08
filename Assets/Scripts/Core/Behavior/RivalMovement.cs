using AFootball.Core.Helpers;
using AFootball.Core.Input;
using AFootball.Core.Scriptables;
using UnityEngine;

namespace AFootball.Core.Behavior
{
    public class RivalMovement : Movement
    {
        private readonly float movementSpeed;

        private readonly Rigidbody playerRb;
        private readonly CharacterSettings playerSettings;
        private Vector3 _targetPosition = Vector3.zero;

        public RivalMovement(IInput characterInput, Rigidbody rigidbodyToMove, CharacterSettings settings,
            Rigidbody plRigidbody) : base(
            characterInput, rigidbodyToMove, settings)
        {
            playerRb = plRigidbody;
            movementSpeed = _settings.isRandomSpeed
                ? Random.Range(3f, 12f)
                : _settings.Speed;
        }

        public override void Tick()
        {
            if (Time.frameCount % 4 != 0)
                return;

            _targetPosition = InterceptCalculator.CalculateInterceptionPoint(_rigidbodyToMove.position, movementSpeed,
                playerRb.position, playerRb.velocity);

            Debug.DrawLine(_rigidbodyToMove.position, _targetPosition, Color.blue);

            DoMove(_targetPosition);
        }

        private void DoMove(Vector3 targetPos)
        {
            var moveDirection = (targetPos - _rigidbodyToMove.position).normalized;
            _rigidbodyToMove.MoveRotation(Quaternion.Lerp(_rigidbodyToMove.rotation,
                Quaternion.LookRotation(moveDirection), _settings.RotationSpeed * Time.deltaTime));
            _rigidbodyToMove.MovePosition(moveDirection * (movementSpeed * Time.deltaTime) + _rigidbodyToMove.position);
        }
    }
}