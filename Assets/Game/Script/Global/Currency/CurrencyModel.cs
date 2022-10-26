using System.Collections;
using System.Collections.Generic;
using Agate.MVC.Base;
using UnityEngine;

namespace Shadee.ConTW
{
    public interface ICurrencyModel : IBaseModel
    {
        public int Coin { get;}
    }
    public class CurrencyModel : BaseModel, ICurrencyModel
    {
        public int Coin { get; set; }

        public CurrencyModel()
        {
        }

        public void SetCoin(int value)
        {
            Coin = value;
            SetDataAsDirty();
        }

        public void Add(int value)
        {
            Coin += value;
            SetDataAsDirty();
        }

        public bool Spend(int value)
        {
            if (Coin >= value)
            {
                Coin -= value;
                SetDataAsDirty();
                return true;
            }
            return false;
        }
    }
}
