using System;
using System.Collections;
using System.Collections.Generic;
using Agate.MVC.Base;
using UnityEngine;

namespace Shadee.ConTW.Gameplay.CoinBucket
{
    public class CoinBucketController : ObjectController<CoinBucketController, CoinBucketModel, ICoinBucketModel, CoinBucketView>
    {
        private CurrencyController _currencyController;
        public override IEnumerator Initialize()
        {
            yield return base.Initialize();
        }

        public override IEnumerator Finalize()
        {
            yield return base.Finalize();
        }

        public void OnGameplayEnd(GameplayEndMessage message)
        {
            _currencyController.AddCoin(_model.Coin);
        }

        public override void SetView(CoinBucketView view)
        {
            base.SetView(view);
        }

        public void OnKeyCorrect(KeyCorrectMessage message)
        {
            _model.AddCoin(message.Reward);
        }
    }
}
