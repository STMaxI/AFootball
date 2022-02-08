using UnityEngine;

namespace AFootball.Core.Input
{
    public class AIInput: IInput
    {
        public void ReadInput()
        {
            AngularRotation = Vector3.one;
            Trust = Vector3.one;
        }

        public Vector3 AngularRotation { get; private set; }
        public Vector3 Trust { get; private set; }
    }
}