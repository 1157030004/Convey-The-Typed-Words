using System;
using System.Collections;
using System.Collections.Generic;
using Agate.MVC.Base;
using UnityEngine;

namespace Shadee.ConTW.Gameplay.Cinematics
{
    public class CinematicsController : ObjectController<CinematicsController, CinematicsModel, ICinematicsModel, CinematicsView>
    {
        public override IEnumerator Initialize()
        {
            return base.Initialize();
        }

        public override void SetView(CinematicsView view)
        {
            base.SetView(view);
            _view.PlayMiddleSequence(PlayMiddleSequence);
        }

        public IEnumerator PlayMiddleSequence()
        {
            while (true)
            {
                Debug.Log("PlayMiddleSequence");
                yield return new WaitForSeconds(60);
                _view.MiddleSequence.Play();
            }
        }
       
    }
}
