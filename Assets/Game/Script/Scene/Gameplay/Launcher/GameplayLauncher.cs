using System.Collections;
using System.Collections.Generic;
using Agate.MVC.Base;
using Agate.MVC.Core;
using Shadee.ConTW.Gameplay.Typer;
using Shadee.ConTW.Gameplay.WordStream;
using UnityEngine;

namespace Shadee.ConTW.Gameplay
{
    public class GameplayLauncher : SceneLauncher<GameplayLauncher, GameplayView>
    {
        public override string SceneName { get { return "Gameplay"; } }

        public WordStreamController _wordStreamController;

        protected override IConnector[] GetSceneConnectors()
        {
            return new IConnector[]{
                new WordStreamConnector(),
            };
        }

        protected override IController[] GetSceneDependencies()
        {
            return new IController[]{
                new WordStreamController(),
                new TyperController(),
            };
        }

        protected override IEnumerator InitSceneObject()
        {
            _view.Init(SceneName, Back);
            _wordStreamController.SetView(_view.WordStreamView);
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
