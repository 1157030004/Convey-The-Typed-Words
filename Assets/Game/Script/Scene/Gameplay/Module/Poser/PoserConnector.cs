using System.Collections;
using System.Collections.Generic;
using Agate.MVC.Base;
using UnityEngine;

namespace Shadee.ConTW.Gameplay.Poser
{
    public class PoserConnector : BaseConnector
    {
        private PoserController _poserController;

        public void OnWordCompleted(NewWordMessage message)
        {
            _poserController.ChangeAnimation(message);
        }
        protected override void Connect()
        {
            Subscribe<NewWordMessage>(OnWordCompleted);
        }

        protected override void Disconnect()
        {
            Unsubscribe<NewWordMessage>(OnWordCompleted);
        }
    }
}
