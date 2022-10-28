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
        [SerializeField] private GameObject _introSequence;
        [SerializeField] private GameObject _middleSequence;
        // [SerializeField] private AudioClip _backSong;
        [HideInInspector] public PlayableDirector IntroSequence;
        [HideInInspector] public PlayableDirector MiddleSequence;

        public void StartSequences(List<Func<IEnumerator>> sequences)
        {
            // foreach inem in playSequence, start coroutine
            foreach(var sequence in sequences)
            {
                StartCoroutine(sequence());
            }
        }
        protected override void InitRenderModel(ICinematicsModel model)
        {
            // get playable director from middlesquence game object
            IntroSequence = _introSequence.GetComponent<PlayableDirector>();
            MiddleSequence = _middleSequence.GetComponent<PlayableDirector>();
        }

        protected override void UpdateRenderModel(ICinematicsModel model)
        {
        }
    }

}
