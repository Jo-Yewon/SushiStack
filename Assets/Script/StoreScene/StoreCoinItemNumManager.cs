using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreCoinItemNumManager : MonoBehaviour
{
    public GameObject CoinText;
    public GameObject LuckyCatNumText;

    public void UpdateCoinItemNum()
    {
        CoinText.GetComponent<Text>().text = "x "+PlayerDataLoad.playerdata.coin.ToString();
        LuckyCatNumText.GetComponent<Text>().text = "x "+PlayerDataLoad.playerdata.item_luckycat_num.ToString();
    }

    public void Start()
    {
        UpdateCoinItemNum();
    }
}
