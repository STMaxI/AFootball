using System;
using AFootball.Core.Interfaces;
using UnityEngine;

namespace AFootball.Core.UI
{
    public abstract class Popup: MonoBehaviour
    {
        protected IHUDActionCallbacks _actionCallback;

        protected Canvas _canvas;

        private void Awake()
        {
            TryGetComponent(out _canvas);
            ClosePopup();
        }

        public void ShowPopup()
        {
            _canvas.enabled = true;
        }

        public void ClosePopup()
        {
            _canvas.enabled = false;
        }

        public void Init(IHUDActionCallbacks actionCallback)
        {
            _actionCallback = actionCallback;
        }
        
        public abstract void ButtonPress();
    }
}