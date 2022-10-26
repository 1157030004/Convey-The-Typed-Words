using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shadee.ConTW.Bundle
{
    public struct UpdateCoinMessage
    {
        public int Coin {get; private set;}

        public UpdateCoinMessage(int remainingCoins)
        {
            Coin = remainingCoins;
        }
    }
}
