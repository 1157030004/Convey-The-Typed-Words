using System;
using System.Collections;
using System.Collections.Generic;
using Agate.MVC.Base;
using UnityEngine;

namespace Shadee.ConTW.Bundle
{
    public class BundleItemController : ObjectController<BundleItemController, BundleItemModel, IBundleItemModel, BundleItemView> 
    {
        private CurrencyController _currency;
        private SaveDataController _saveData;
        public void Init(BundleItemModel model, BundleItemView view)
        {
            _model = model;
            SetView(view);
            _view.Init(UnlockBundle);
            _view.OpenBundle(OpenBundle);
        }

        private void UnlockBundle()
        {
            if(!_currency.SpendCoin(_model.UnlockCost))
            {
                Debug.Log("Not enough coin");
                return;
            }

            _model.Unlock();
            _view.SetLockState(_model.IsLocked);
            Publish<UnlockBundleMessage>(new UnlockBundleMessage(_model.Bundle.ID, _currency.GetCurrentCoin()));
            Publish<UpdateCoinMessage>(new UpdateCoinMessage(_currency.GetCurrentCoin()));
        }

        private void OpenBundle()
        {
            if(_model.IsLocked)
            {
                Debug.Log("Bundle is locked");
                return;
            }

            _saveData.SetBundlePickedID(_model.Bundle.ID);
            SceneLoader.Instance.LoadScene("Gameplay");
            Publish<OpenBundleMessage>(new OpenBundleMessage(_model.Bundle.ID));
        }

        public override IEnumerator Initialize()
        {
            yield return base.Initialize();
        }

        public override IEnumerator Finalize()
        {
            yield return base.Finalize();
        }
    }
}
