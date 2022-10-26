
using Agate.MVC.Base;
using TMPro;
using UnityEngine;

namespace Shadee.ConTW.Bundle.Overlay
{
    public class OverlayView : ObjectView<IOverlayModel>
    {
        [SerializeField] private TextMeshProUGUI _currentCoin;
        protected override void InitRenderModel(IOverlayModel model)
        {
            _currentCoin.text = model.Coin.ToString();
        }

        protected override void UpdateRenderModel(IOverlayModel model)
        {
            _currentCoin.text = model.Coin.ToString();
        }
    }
}
