using System;
using System.Collections;
using System.Collections.Generic;
using Agate.MVC.Base;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Shadee.ConTW.Gameplay.Typer
{
    public class TyperView : ObjectView<ITyperModel>
    {
        [SerializeField] private Button _keyButton;
        [SerializeField] private TextMeshProUGUI _keyText;

        private string _selectedKey;
        private string _buttonId;
        public string SeletctedKey => _selectedKey;
        public string ButtonId => _buttonId;

        public void SelectKey(UnityAction onKeySelected)
        {
            _keyButton.onClick.RemoveAllListeners();
            _keyButton.onClick.AddListener(onKeySelected);
            _selectedKey = _keyText.text;
            _buttonId = _keyButton.name;
        }
        protected override void InitRenderModel(ITyperModel model)
        {
        }

        protected override void UpdateRenderModel(ITyperModel model)
        {
        }
    }
}
