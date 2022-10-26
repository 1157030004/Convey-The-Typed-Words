using System;
using System.Collections;
using System.Collections.Generic;
using Agate.MVC.Base;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Shadee.ConTW.Gameplay.Countdown
{
public class CountdownView : ObjectView<ICountdownModel>
    {
        [SerializeField] private TextMeshProUGUI _countdownText;

        private UnityAction _onCountdownStarted;

        internal void SetCountdown(Func<IEnumerator> startCountdown)
        {
            StartCoroutine(startCountdown());
        }

        private string ConvertTimeToString(float time)
        {
            int intTime = (int)time;
            int minutes = intTime / 60;
            int seconds = intTime % 60;
            return string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        protected override void InitRenderModel(ICountdownModel model)
        {
            _countdownText.text = ConvertTimeToString(model.remainingTime);
        }

        protected override void UpdateRenderModel(ICountdownModel model)
        {
            _countdownText.text = ConvertTimeToString(model.remainingTime);
            _onCountdownStarted?.Invoke();
        }
    }
}
