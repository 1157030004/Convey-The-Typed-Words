using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shadee.ConTW.Bundle
{
    public struct UnlockBundleMessage
    {
        public string BundleID {get; private set;}
        public int CoinLeft {get; private set;}

        public UnlockBundleMessage(string bundleID, int coinLeft)
        {
            BundleID = bundleID;
            CoinLeft = coinLeft;
        }
    }
}
