using System.Collections;
using System.Collections.Generic;
using Agate.MVC.Base;
using Agate.MVC.Core;
using Shadee.ConTW.Bundle.Overlay;
using UnityEngine;

namespace Shadee.ConTW.Bundle
{
    public class BundleLauncher : SceneLauncher<BundleLauncher, BundleView>
    {
        public override string SceneName { get { return "Bundle"; } }

        public BundleListController _bundleListController;
        public OverlayController _overlayController;

        protected override IConnector[] GetSceneConnectors()
        {
            return new IConnector[]{
                new BundleItemConnector(),
                new OverlayConnector(),
            };
        }

        protected override IController[] GetSceneDependencies()
        {
            return new IController[]{
                new BundleListController(),
                new OverlayController(),
            };
        }

        protected override IEnumerator InitSceneObject()
        {
            _view.Init(SceneName, BackToHome, Restart);
            _bundleListController.SetView(_view.BundleList);
            _overlayController.SetView(_view.Overlay);
            yield return null;
        }

        protected override IEnumerator LaunchScene()
        {
            return null;
        }

        private void BackToHome()
        {
            SceneLoader.Instance.LoadScene("Home");
        }

        private void Restart()
        {
            SceneLoader.Instance.RestartScene();
        }
    }
}
