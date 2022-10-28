using System;
using System.Collections;
using Agate.MVC.Base;
using Shadee.ConTW.Gameplay.CoinBucket;
using UnityEngine;

namespace Shadee.ConTW.Gameplay.Countdown
{
    public class CountdownController : ObjectController<CountdownController, CountdownModel, ICountdownModel, CountdownView>
    {
        private CoinBucketController _coinBucketController;
        private float _timeLeft;
        private bool _shouldStartCountdown = false;

        public void OnCinematicEnd(CinematicEndMessage message)
        {
            Debug.Log("Cinematic ended");
            _shouldStartCountdown = true;
            Debug.Log("Countdown started is " + _shouldStartCountdown);
        }

        public override void SetView(CountdownView view)
        {
            base.SetView(view);
            _view.SetCountdown(StartCountdown);
        }

        public void OnCountdownReset()
        {
            Debug.Log("Countdown Reset");
            _timeLeft = _model.defaultTime;
        }

        public IEnumerator StartCountdown()
        {
            _timeLeft = _model.defaultTime;
            while (_timeLeft > 0)
            {
                Debug.Log(_shouldStartCountdown);
                // if shouldStart is falese, then it will not start the countdown
                if (_shouldStartCountdown)
                {
                    _timeLeft -= Time.deltaTime;
                    _model.SetRemainingTime(_timeLeft);
                }
                yield return null;
            }
            SceneLoader.Instance.LoadScene("Bundle");
            Publish<GameplayEndMessage>(new GameplayEndMessage());
        }
    }
}
