using Agate.MVC.Base;
using UnityEngine;

namespace Shadee.ConTW.Bundle
{
    public class BundleListController : ObjectController<BundleListController, BundleListModel, IBundleListModel, BundleListView>
    {

        private DatabaseController _database;
        private SaveDataController _saveData;
        public override void SetView(BundleListView view)
        {
            base.SetView(view);

            var data = _database.BundleList;
            for (int i = 0; i < data.Count; i++)
            {
                ShowBundle(data[i], !IsBundleUnlocked(data[i].ID), IsBundleCompleted(data[i].ID), i);
            }
        }

        private bool IsBundleCompleted(string id)
        {
            return _saveData.IsBundleCompleted(id);
        }

        private bool IsBundleUnlocked(string id)
        {
            return _saveData.IsBundleUnlocked(id);
        }

        private void ShowBundle(BundleSO bundle, bool isLocked, bool isCompleted, int unlockCost)
        {
            int baseCost = 50 * unlockCost;
            BundleItemModel model = new BundleItemModel(bundle, isLocked, isCompleted, baseCost);
            GameObject obj = _view.CreateBundleItemObject(bundle);
            BundleItemView view = obj.GetComponent<BundleItemView>();
            BundleItemController controller = new BundleItemController();
            InjectDependencies(controller);
            controller.Init(model, view);
            _model.AddBundle(controller);
        }
    }
}
