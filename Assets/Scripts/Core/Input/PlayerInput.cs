using UnityEngine;

namespace AFootball.Core.Input
{
    public class PlayerInput: IInput
    {
        public void ReadInput()
        {
            AngularRotation = UnityEngine.Input.GetAxis("Horizontal") * Vector3.one;
            Trust = UnityEngine.Input.GetAxis("Vertical") * Vector3.one;
        }

        public Vector3 AngularRotation { get; private set; }
        public Vector3 Trust { get; private set; }
    }
}