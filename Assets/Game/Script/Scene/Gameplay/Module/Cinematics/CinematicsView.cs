using System;
using System.Collections;
using System.Collections.Generic;
using Agate.MVC.Base;
using UnityEngine;
using UnityEngine.Playables;

namespace Shadee.ConTW.Gameplay.Cinematics
{
    public class CinematicsView : ObjectView<ICinematicsModel>
    {
        [SerializeField] private GameObject _middleSequence;
        // [SerializeField] private AudioClip _backSong;
        [HideInInspector] public PlayableDirector MiddleSequence;

        public void PlayMiddleSequence(Func<IEnumerator> playSequence)
        {
            StartCoroutine(playSequence());
        }
        protected override void InitRenderModel(ICinematicsModel model)
        {
            // get playable director from middlesquence game object
            MiddleSequence = _middleSequence.GetComponent<PlayableDirector>();
        }

        protected override void UpdateRenderModel(ICinematicsModel model)
        {
        }
    }

}
