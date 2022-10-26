using System.Collections;
using System.Collections.Generic;
using Agate.MVC.Base;
using UnityEngine;

namespace Shadee.ConTW.Gameplay.CoinBucket
{
    public interface ICoinBucketModel : IBaseModel
    {
        public int Coin {get;}
    }
    public class CoinBucketModel : BaseModel, ICoinBucketModel
    {
        public int Coin {get; private set;}

        public void AddCoin(int coin)
        {
            Coin += coin;
            SetDataAsDirty();
        }
    }
}
