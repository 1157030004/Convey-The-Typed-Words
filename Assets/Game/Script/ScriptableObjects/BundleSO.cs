using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shadee.ConTW
{
    [CreateAssetMenu(fileName = "Bundle", menuName = "Game/New Bundle")]
    public class BundleSO : ScriptableObject
    {
        public string ID = Guid.NewGuid().ToString();
        public string Name;
        [TextArea] public string Description;
    }
}
