using System.Collections;
using System.Collections.Generic;
using Agate.MVC.Base;
using UnityEngine;

namespace Shadee.ConTW.Bundle.Overlay
{
    public class OverlayController : ObjectController<OverlayController, OverlayModel, IOverlayModel, OverlayView>
    {
        private CurrencyController _currency;
        public override void SetView(OverlayView view)
        {
            base.SetView(view);
        }

        public void SetCoinText(int coin)
        {
            _model.SetCoin(coin);
        }

        public override IEnumerator Initialize()
        {
            yield return base.Initialize();
        }


        public override IEnumerator Finalize()
        {
            yield return base.Finalize();
            _model.SetCoin(_currency.GetCurrentCoin());
        }
    }
}
