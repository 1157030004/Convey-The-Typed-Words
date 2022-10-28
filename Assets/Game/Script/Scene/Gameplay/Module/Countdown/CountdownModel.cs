using System.Collections;
using System.Collections.Generic;
using Agate.MVC.Base;
using UnityEngine;

namespace Shadee.ConTW.Gameplay.Countdown
{
    public interface ICountdownModel : IBaseModel
    {
        public float remainingTime { get; }
        public float defaultTime { get; }
    }
    public class CountdownModel : BaseModel, ICountdownModel
    {
        public float remainingTime { get; private set; }
        public float defaultTime { get; private set; } = 400;

        public void SetRemainingTime(float time)
        {
            remainingTime = time;
            SetDataAsDirty();
        }
    }
}
