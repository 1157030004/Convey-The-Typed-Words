using System.Collections;
using System.Collections.Generic;
using Agate.MVC.Base;
using UnityEngine;

namespace Shadee.ConTW.Bundle
{
    public interface IBundleListModel : IBaseModel
    {
    }
    public class BundleListModel : BaseModel, IBundleListModel
    {

        List<BundleItemController> BundleItems => new List<BundleItemController>();

        public void AddBundle(BundleItemController bundle)
        {
            BundleItems.Add(bundle);
            SetDataAsDirty();
        }
    }
}
