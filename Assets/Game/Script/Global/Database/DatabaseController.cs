using System.Collections;
using System.Collections.Generic;
using Agate.MVC.Base;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Shadee.ConTW
{
    public class DatabaseController : BaseController<DatabaseController>
    {
        public List<BundleSO> BundleList { get; private set; } = new List<BundleSO>();

        public void LoadAllBundle()
        {
            Addressables.InitializeAsync().Completed += (op) =>
            {
                Addressables.LoadAssetsAsync<BundleSO>("bundle", null).Completed += (go) =>
                {
                        BundleList = go.Result as List<BundleSO>;
                        Debug.Log("Bundle Count: " + BundleList.Count);
                };
            };
        }

        public override IEnumerator Initialize()
        {
            yield return base.Initialize();
            LoadAllBundle();
        }
          
    }
}
