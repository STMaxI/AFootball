using AFootball.Core.Interfaces;
using UnityEngine;

namespace AFootball.Core.UI
{
    public class GameOverPopup: Popup
    {
        public override void ButtonPress()
        {
            ClosePopup();
            _actionCallback?.OnStartPopupClose();
        }
    }
}