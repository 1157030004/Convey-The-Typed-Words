using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shadee.ConTW.Gameplay
{
    public struct NewWordMessage
    {
        public int ID {get;}

        public NewWordMessage(int id)
        {
            ID = id;
        }
    }
}
