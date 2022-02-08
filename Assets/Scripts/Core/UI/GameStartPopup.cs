using AFootball.Core.Interfaces;
using UnityEngine;

namespace AFootball.Core.UI
{
    public class GameStartPopup: Popup
    {
        public override void ButtonPress()
        {
            ClosePopup();
            _actionCallback?.OnGameOverPopupClose();
        }
    }
}