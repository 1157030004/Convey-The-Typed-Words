using System.Collections;
using System.Collections.Generic;
using Agate.MVC.Base;
using Shadee.ConTW.Gameplay.Countdown;
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
        [SerializeField] private Button _backButton;

        public WordStreamView WordStreamView => _wordStreamView;
        public CountdownView CountdownView { get { return _countdownView; } }

        public void Init(string sceneName, UnityAction onBack)
        {
            _backButton.onClick.RemoveAllListeners();
            _backButton.onClick.AddListener(onBack);
        }
    }
}
