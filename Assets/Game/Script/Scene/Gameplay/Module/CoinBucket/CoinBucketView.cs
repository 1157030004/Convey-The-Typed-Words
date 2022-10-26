using System.Collections;
using System.Collections.Generic;
using Agate.MVC.Base;
using TMPro;
using UnityEngine;

namespace Shadee.ConTW.Gameplay.CoinBucket
{
    public class CoinBucketView : ObjectView<ICoinBucketModel>
    {
        [SerializeField] private TextMeshProUGUI _coinText;
        protected override void InitRenderModel(ICoinBucketModel model)
        {
            _coinText.text = model.Coin.ToString();
        }

        protected override void UpdateRenderModel(ICoinBucketModel model)
        {
            _coinText.text = model.Coin.ToString();
        }
    }
}
