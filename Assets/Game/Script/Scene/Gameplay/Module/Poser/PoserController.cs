using System;
using System.Collections;
using System.Collections.Generic;
using Agate.MVC.Base;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Shadee.ConTW.Gameplay.Poser
{
    public class PoserController : ObjectController<PoserController, PoserModel, IPoserModel, PoserView>
    {
        public override void SetView(PoserView view)
        {
            base.SetView(view);
            _view.Init();
            _view.SetPosing(StartPosing);

        }

        public void ChangeAnimation(NewWordMessage message)
        {
            _view.Animator.SetTrigger("isPosing");
        }

        private IEnumerator StartPosing()
        {
            while (true)
            {
                yield return new WaitForSeconds(3);
                _view.Animator.SetInteger("poseIndex", Random.Range(0, 5));
            }
        }
    }
}
