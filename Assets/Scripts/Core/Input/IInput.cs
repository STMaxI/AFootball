using UnityEngine;

namespace AFootball.Core.Input
{
    public interface IInput
    {
        public void ReadInput();
        public Vector3 AngularRotation { get; }
        public Vector3 Trust { get; }
    }
}
