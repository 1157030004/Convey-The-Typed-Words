using System.Collections;
using System.Collections.Generic;
using Agate.MVC.Base;
using Agate.MVC.Core;
using Shadee.ConTW.Gameplay.CoinBucket;
using Shadee.ConTW.Gameplay.Countdown;
using Shadee.ConTW.Gameplay.Poser;
using Shadee.ConTW.Gameplay.Sound;
using Shadee.ConTW.Gameplay.Typer;
using Shadee.ConTW.Gameplay.WordStream;
using UnityEngine;

namespace Shadee.ConTW.Gameplay
{
    public class GameplayLauncher : SceneLauncher<GameplayLauncher, GameplayView>
    {
        public override string SceneName { get { return "Gameplay"; } }

        public WordStreamController _wordStreamController;
        private CountdownController _countdownController;
        private CoinBucketController _coinBucketController;
        private PoserController _poserController;

        protected override IConnector[] GetSceneConnectors()
        {
            return new IConnector[]{
                new WordStreamConnector(),
                new CoinBucketConnector(),
                new PoserConnector(),
            };
        }

        protected override IController[] GetSceneDependencies()
        {
            return new IController[]{
                new WordStreamController(),
                new TyperController(),
                new CountdownController(),
                new CoinBucketController(),
                new PoserController(),
                new SoundController(),
            };
        }

        protected override IEnumerator InitSceneObject()
        {
            _view.Init(SceneName, Back);
            _wordStreamController.SetView(_view.WordStreamView);
            _countdownController.SetView(_view.CountdownView);
            _coinBucketController.SetView(_view.CoinBucketView);
            _poserController.SetView(_view.PoserView);
            yield return null;
        }

        protected override IEnumerator LaunchScene()
        {
            return null;
        }
        private void Back()
        {
            SceneLoader.Instance.LoadScene("Bundle");
        }

    }
}
