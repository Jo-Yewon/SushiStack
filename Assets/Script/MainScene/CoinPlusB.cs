using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPlusB : MonoBehaviour
{
    public void coinPlusButtonClicked()
    {
        PlayerDataLoad.playerdata.coin += 1000;
        PlayerDataLoad.SaveData();
    }
}
