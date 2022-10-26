using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shadee.ConTW.Gameplay
{
    public struct KeyCorrectMessage
    {
        public int Reward {get;}
        public KeyCorrectMessage(int reward)
        {
            Reward = reward;
        }
    }
}
