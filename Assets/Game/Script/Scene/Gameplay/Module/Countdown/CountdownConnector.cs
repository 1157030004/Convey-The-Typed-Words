using System.Collections;
using System.Collections.Generic;
using Agate.MVC.Base;
using UnityEngine;

namespace Shadee.ConTW.Gameplay.Countdown
{
    public class CountdownConnector : BaseConnector
    {
        private CountdownController _controller;
        
        public void OnCinematicEnd(CinematicEndMessage message)
        {
            _controller.OnCinematicEnd(message);
        }
        protected override void Connect()
        {
            Subscribe<CinematicEndMessage>(OnCinematicEnd);
        }

        protected override void Disconnect()
        {
            Unsubscribe<CinematicEndMessage>(OnCinematicEnd);
        }
    }
}
