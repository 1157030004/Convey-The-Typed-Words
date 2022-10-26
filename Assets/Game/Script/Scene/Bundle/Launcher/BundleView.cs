using System.Collections;
using System.Collections.Generic;
using Agate.MVC.Base;
using Shadee.ConTW.Bundle.Overlay;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Shadee.ConTW.Bundle
{
    public class BundleView : BaseSceneView
    {
        [SerializeField] private BundleListView _bundleList;
        [SerializeField] private OverlayView _overlay;
        [SerializeField] private Button _homeButton;
        [SerializeField] private Button _restartButton;

        public BundleListView BundleList => _bundleList;
        public OverlayView Overlay {get {return _overlay;}}
        
        public void Init(string sceneName, UnityAction onHome, UnityAction onRestart)
        {
            _homeButton.onClick.RemoveAllListeners();
            _homeButton.onClick.AddListener(onHome);

            _restartButton.onClick.RemoveAllListeners();
            _restartButton.onClick.AddListener(onRestart);
        }
    }
}
