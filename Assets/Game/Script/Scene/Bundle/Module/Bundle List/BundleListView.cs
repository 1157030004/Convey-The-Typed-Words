using System.Collections;
using System.Collections.Generic;
using Agate.MVC.Base;
using UnityEngine;

namespace Shadee.ConTW.Bundle
{
    public class BundleListView : ObjectView<IBundleListModel>
    {
        [SerializeField] private RectTransform _bundleItemContainer;
        [SerializeField] private GameObject _bundleItemTempalte;

        public GameObject CreateBundleItemObject(BundleSO bundle)
        {
            GameObject obj = GameObject.Instantiate(_bundleItemTempalte, _bundleItemContainer);
            obj.name = bundle.ID.ToString();
            obj.SetActive(true);
            return obj;
        }
        protected override void InitRenderModel(IBundleListModel model)
        {
        }

        protected override void UpdateRenderModel(IBundleListModel model)
        {
        }
    }
}
