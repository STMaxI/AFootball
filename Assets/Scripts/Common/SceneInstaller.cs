using System;
using AFootball.Core;
using AFootball.Core.Behavior;
using Zenject;

namespace AFootball.Common
{
    public class SceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerMovement>().AsSingle();
        }
    }
}