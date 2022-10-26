using System.Collections;
using System.Collections.Generic;
using Agate.MVC.Base;
using UnityEngine;

namespace Shadee.ConTW
{
    public class CurrencyController : DataController<CurrencyController, CurrencyModel, ICurrencyModel>
    {
        public SaveDataController _saveData;

        public int GetCurrentCoin()
        {
            return _model.Coin;
        }

        public bool SpendCoin(int value)
        {
            return _model.Spend(value);
        }

        public override IEnumerator Finalize()
        {
            yield return base.Finalize();
            _model.SetCoin(_saveData.Model.Progress.Coin);
        }
    }
}
