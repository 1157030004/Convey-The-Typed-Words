using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shadee.ConTW.Gameplay
{
    public struct CinematicEndMessage
    {
        public string Description {get;}
        public CinematicEndMessage(string description)
        {
            Description = description;
        }
    }
}
