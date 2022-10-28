using System.Collections;
using System.Collections.Generic;
using Agate.MVC.Base;
using Shadee.ConTW.Gameplay.Cinematics;
using Shadee.ConTW.Gameplay.CoinBucket;
using Shadee.ConTW.Gameplay.Countdown;
using Shadee.ConTW.Gameplay.Poser;
using Shadee.ConTW.Gameplay.WordStream;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Shadee.ConTW
{
    public class GameplayView : BaseSceneView
    {
        [SerializeField] private WordStreamView _wordStreamView;
        [SerializeField] private CountdownView _countdownView;
        [SerializeField] private CoinBucketView _coinBucketView;
        [SerializeField] private CinematicsView _cinematicsView;
        [SerializeField] private PoserView _poserView;
        [SerializeField] private Button _backButton;

        public WordStreamView WordStreamView => _wordStreamView;
        public CountdownView CountdownView => _countdownView;
        public CoinBucketView CoinBucketView => _coinBucketView;
        public PoserView PoserView => _poserView;
        public CinematicsView CinematicsView => _cinematicsView;

        public void Init(string sceneName, UnityAction onBack)
        {
            _backButton.onClick.RemoveAllListeners();
            _backButton.onClick.AddListener(onBack);
        }
    }
}
