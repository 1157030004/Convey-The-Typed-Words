using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Shadee.ConTW.Gameplay
{
    public struct KeySelectedMessage
    {
        public string ButtonId {get;}
        public string SelectedKey {get;}

        public KeySelectedMessage(string buttonId, string selectedKey)
        {
            ButtonId = buttonId;
            SelectedKey = selectedKey;
        }
    }
}
