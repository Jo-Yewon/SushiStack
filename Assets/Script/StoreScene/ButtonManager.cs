#pragma warning disable 0168

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public GameObject LuckyCatGraphic;
    public GameObject LuckyCatTag;
    public GameObject MyStoreCoinItemNumManager;
    public GameObject CoinLackText;

    private readonly static int LuckyCatPrice = 150;
    private PlayerDataLoad.PlayerData playerdata;

    public void Start()
    {
        try
        {
            playerdata = PlayerDataLoad.playerdata;
        }
        catch (Exception e) { }
        LuckyCatGraphic.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
    }

    public void BackButtonClicked()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void LuckyCatClicked() //행운의 고양이 item 클릭시
    {
        try
        {
            if (playerdata.coin >= LuckyCatPrice) //돈이 충분하면
            {
                gameObject.GetComponent<AudioSource>().Play();
                playerdata.item_luckycat_num++;
                playerdata.coin -= LuckyCatPrice;
                PlayerDataLoad.SaveData();
                MyStoreCoinItemNumManager.GetComponent<StoreCoinItemNumManager>().UpdateCoinItemNum();
            }
            else
            {
                CoinLackText.SetActive(true);
            }
        }
        catch (Exception e) { }
    }
}
