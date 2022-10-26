using Agate.MVC.Base;

namespace Shadee.ConTW.Bundle
{
    public class BundleItemConnector : BaseConnector
    {
        private SaveDataController _saveData;

        public void OnUnlockBundle(UnlockBundleMessage message)
        {
            _saveData.UnlockBundle(message.BundleID, message.CoinLeft);
            _saveData.SetCoinData(message.CoinLeft);
        }

        protected override void Connect()
        {
            Subscribe<UnlockBundleMessage>(OnUnlockBundle);
        }

        protected override void Disconnect()
        {
            Unsubscribe<UnlockBundleMessage>(OnUnlockBundle);
        }
    }
}
