using System.Collections;
using System.Collections.Generic;
using Agate.MVC.Base;
using UnityEngine;

namespace Shadee.ConTW.Gameplay.WordStream
{
    public class WordStreamConnector : BaseConnector
    {
        private WordStreamController _controller;

        public void OnKeySelected(KeySelectedMessage message)
        {
            _controller.CheckKey(message);
        }

        protected override void Connect()
        {
            Subscribe<KeySelectedMessage>(OnKeySelected);
        }

        protected override void Disconnect()
        {
            Unsubscribe<KeySelectedMessage>(OnKeySelected);
        }
    }
}
