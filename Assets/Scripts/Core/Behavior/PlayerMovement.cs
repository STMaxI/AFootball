using AFootball.Core.Input;
using AFootball.Core.Scriptables;
using UnityEngine;

namespace AFootball.Core.Behavior
{
    internal class PlayerMovement : Movement
    {
        private float movementSpeed;

        public PlayerMovement(IInput characterInput, Rigidbody rigidbodyToMove, CharacterSettings settings) : base(
            characterInput, rigidbodyToMove, settings)
        {
            movementSpeed = _settings.isRandomSpeed
                ? Random.Range(2f, 10f)
                : _settings.Speed;
        }

        public override void Tick()
        {
            var rotationAngle = _characterInput.AngularRotation.x * _settings.RotationSpeed * Time.deltaTime;

            _rigidbodyToMove.MoveRotation(_rigidbodyToMove.rotation * Quaternion.Euler(0, rotationAngle, 0));

            _rigidbodyToMove.ResetInertiaTensor();
            Vector3 velocityVector = _rigidbodyToMove.transform.forward *
                                     (_characterInput.Trust.y * movementSpeed * Time.deltaTime);

            _rigidbodyToMove.AddForce(velocityVector, ForceMode.VelocityChange);
        }
    }
}