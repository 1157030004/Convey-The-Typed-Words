using System.Collections;
using System.Collections.Generic;
using Agate.MVC.Base;
using UnityEngine;

namespace Shadee.ConTW.Bundle.Overlay
{
    public interface IOverlayModel : IBaseModel
    {
        public int Coin { get; }
    }

    public class OverlayModel : BaseModel, IOverlayModel
    {
        public int Coin { get; private set; }

        public void SetCoin(int coin)
        {
            Coin = coin;
            SetDataAsDirty();
        }
    }
}
