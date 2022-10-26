using System.Collections;
using Agate.MVC.Base;
using Shadee.ConTW.Gameplay.CoinBucket;
using UnityEngine;

namespace Shadee.ConTW.Gameplay.Countdown
{
    public class CountdownController : ObjectController<CountdownController, CountdownModel, ICountdownModel, CountdownView>
    {
        private CoinBucketController _coinBucketController;
        private float timeLeft;

        public override void SetView(CountdownView view)
        {
            base.SetView(view);
            _view.SetCountdown(StartCountdown);
        }

        public void OnCountdownReset()
        {
            Debug.Log("Countdown Reset");
            timeLeft = _model.defaultTime;
        }

        public IEnumerator StartCountdown()
        {
            timeLeft = _model.defaultTime;
            while (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                _model.SetRemainingTime(timeLeft);
                yield return null;
            }
            SceneLoader.Instance.LoadScene("Bundle");
            Publish<GameplayEndMessage>(new GameplayEndMessage());
        }
    }
}
