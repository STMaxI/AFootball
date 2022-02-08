using AFootball.Core.Interfaces;
using UnityEngine;

namespace AFootball.Core.UI
{
    public class VictoryPopup: Popup
    {
        public override void ButtonPress()
        {
            ClosePopup();
            _actionCallback?.OnVictoryPopupClose();
        }
    }
}