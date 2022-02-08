using System;

namespace AFootball.Core.Interfaces
{
    public interface IHUDActionCallbacks
    {
        void OnGameOverPopupClose();
        void OnStartPopupClose();
        void OnVictoryPopupClose();
    }
}