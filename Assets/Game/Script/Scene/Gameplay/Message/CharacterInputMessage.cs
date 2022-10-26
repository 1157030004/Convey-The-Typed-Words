using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shadee.ConTW.Gameplay
{
    public struct CharacterInputMessage
    {
        public string PressedLetter {get; private set;}
        public CharacterInputMessage(string pressedLetter)
        {
            PressedLetter = pressedLetter;
        }
    }
}
