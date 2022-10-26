using Agate.MVC.Base;

namespace Shadee.ConTW.Bundle.Overlay
{
    public class OverlayConnector : BaseConnector
    {
        private OverlayController _overlayController;

        public void OnCoinChange(UpdateCoinMessage message)
        {
            _overlayController.SetCoinText(message.Coin);
        }
        protected override void Connect()
        {
            Subscribe<UpdateCoinMessage>(OnCoinChange);
        }

        protected override void Disconnect()
        {
            Unsubscribe<UpdateCoinMessage>(OnCoinChange);
        }
    }
}
