using System;
using System.Collections;
using System.Collections.Generic;
using Agate.MVC.Base;
using UnityEngine;
using UnityEngine.Playables;

namespace Shadee.ConTW.Gameplay.Cinematics
{
    public class CinematicsController : ObjectController<CinematicsController, CinematicsModel, ICinematicsModel, CinematicsView>
    {
        private List<Func<IEnumerator>> _sequences = new List<Func<IEnumerator>>();
        public override IEnumerator Initialize()
        {
            return base.Initialize();
        }

        public override void SetView(CinematicsView view)
        {
            base.SetView(view);
            _sequences.Add(CheckIntroSequence);
            _sequences.Add(PlayMiddleSequence);
            _view.StartSequences(_sequences);
        }

        public IEnumerator PlayMiddleSequence()
        {
            while (true)
            {
                yield return new WaitForSeconds(60);
                _view.MiddleSequence.Play();
            }
        }

        public IEnumerator CheckIntroSequence()
        {
            while (true)
            {
                if(_view.IntroSequence.state == PlayState.Playing)
                    yield return new WaitForSeconds(1);


                if(_view.IntroSequence.state == PlayState.Paused)
                {
                    Publish<CinematicEndMessage>(new CinematicEndMessage("IntroSequence"));
                    yield break;
                }
            }
        }


       
    }
}
