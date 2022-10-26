using System;
using System.Collections;
using System.Collections.Generic;
using Agate.MVC.Base;
using Shadee.ConTW.Gameplay.Typer;
using UnityEngine;

namespace Shadee.ConTW.Gameplay.Typer
{
    public class TyperController : ObjectController<TyperController, TyperModel, ITyperModel, TyperView>
    {
        public void Init(TyperModel typerModel, TyperView typerView)
        {
            _model = typerModel;
            SetView(typerView);
            _view.SelectKey(onKeySelected);
        }

        private void onKeySelected()
        {
            Publish<KeySelectedMessage>(new KeySelectedMessage(_view.ButtonId, _view.SeletctedKey));
        }
    }
}
