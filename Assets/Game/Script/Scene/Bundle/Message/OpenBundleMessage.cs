using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shadee.ConTW.Bundle
{
    public struct OpenBundleMessage
    {
        public string BundleID { get; private set;}

        public OpenBundleMessage(string bundleID)
        {
            BundleID = bundleID;
        }
    }
}
