using System.Collections;
using System.Collections.Generic;
using Agate.MVC.Base;
using UnityEngine;

namespace Shadee.ConTW
{
    public interface ISaveDataModel : IBaseModel
    {
        public Progress Progress { get;}
        public string PickedBundleID { get; set; }
        public string PickedLevelID { get; set; }
    }

    public class SaveDataModel : BaseModel, ISaveDataModel
    {
        public Progress Progress { get; private set; }
        public string PickedBundleID { get; set; }
        public string PickedLevelID { get; set; }

        public void SetProgressData(Progress progress)
        {
            Progress = progress;
            SetDataAsDirty();
        }

        public void SetPickedBundleID(string bundleID)
        {
            PickedBundleID = bundleID;
            SetDataAsDirty();
        }

        public void SetPickedLevelID(string levelID)
        {
            PickedLevelID = levelID;
            SetDataAsDirty();
        }

        public void SetCoinData(int coin)
        {
            Progress.Coin = coin;
            SetDataAsDirty();
        }

        public void AddUnlockedBundle(string id)
        {
            Progress.UnlockedBundle.Add(id);
            SetDataAsDirty();
        }
    }
}
