using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shadee.ConTW.Gameplay
{
    public struct GameplayEndMessage
    {
        public int Reward {get;}
        public string Description {get;}
        public GameplayEndMessage(int reward, string description)
        {
            Reward = reward;
            Description = description;
        }
    }
}
