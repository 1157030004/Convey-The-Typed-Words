using Agate.MVC.Base;
namespace Shadee.ConTW.Gameplay.CoinBucket
{
    public class CoinBucketConnector : BaseConnector
    {
        private CoinBucketController _controller;

        public void OnKeyCorrect(KeyCorrectMessage message)
        {
            _controller.OnKeyCorrect(message);
        }

        public void OnGameplayEnd(GameplayEndMessage message)
        {
            _controller.OnGameplayEnd(message);
        }
        protected override void Connect()
        {
            Subscribe<KeyCorrectMessage>(OnKeyCorrect);
            Subscribe<GameplayEndMessage>(OnGameplayEnd);
        }

        protected override void Disconnect()
        {
            Unsubscribe<KeyCorrectMessage>(OnKeyCorrect);
            Unsubscribe<GameplayEndMessage>(OnGameplayEnd);
        }
    }
}
