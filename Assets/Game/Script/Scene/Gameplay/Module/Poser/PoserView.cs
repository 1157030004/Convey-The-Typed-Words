using System;
using System.Collections;
using System.Collections.Generic;
using Agate.MVC.Base;
using UnityEngine;

namespace Shadee.ConTW.Gameplay.Poser
{
    public class PoserView : ObjectView<IPoserModel>
    {
        [SerializeField] private Protagonist _protagonist;
        private Animator _animator;

        public Animator Animator => _animator;

        public void SetPosing(Func<IEnumerator> startPosing)
        {
            StartCoroutine(startPosing());
        }
        public void Init()
        {
            _protagonist = FindObjectOfType<Protagonist>();
            _animator = _protagonist.GetComponentInChildren<Animator>();
        }
        protected override void InitRenderModel(IPoserModel model)
        {

        }

        protected override void UpdateRenderModel(IPoserModel model)
        {
        }
    }
}
