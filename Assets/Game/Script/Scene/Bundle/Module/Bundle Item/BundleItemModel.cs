using System.Collections;
using System.Collections.Generic;
using Agate.MVC.Base;
using UnityEngine;

namespace Shadee.ConTW.Bundle
{
    public interface IBundleItemModel : IBaseModel
    {
        public BundleSO Bundle { get; }
        public bool IsLocked { get; }
        public bool IsCompleted { get; }
        public int UnlockCost { get; }
    }
    public class BundleItemModel : BaseModel, IBundleItemModel
    {
        public BundleSO Bundle { get; private set; }
        public bool IsLocked { get; private set; }
        public bool IsCompleted { get; private set; }
        public int UnlockCost { get; private set; }

        public BundleItemModel()
        {
        }

        public BundleItemModel(BundleSO bundle, bool isLocked, bool isCompleted, int unlockCost)
        {
            Bundle = bundle;
            IsLocked = isLocked;
            IsCompleted = isCompleted;
            UnlockCost = unlockCost;
            SetDataAsDirty();
        }

        public bool Unlock()
        {
            if (IsLocked)
            {
                IsLocked = false;
                SetDataAsDirty();
                return true;
            }
            return false;
        }
    }
}
