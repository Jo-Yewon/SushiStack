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

    private static int LuckyCatPrice = 1000;
    private PlayerDataLoad.PlayerData playerdata;

    public void Start()
    {
        try
        {
            playerdata = PlayerDataLoad.playerdata;
        }
        catch (Exception e) { }
        LuckyCatGraphic.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
        LuckyCatTag.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
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
                playerdata.item_luckycat_num++;
                playerdata.coin -= LuckyCatPrice;
                PlayerDataLoad.SaveData();
            }
            else
            {
                Debug.Log("코인이 모자람");
            }
        }
        catch (Exception e) { }
    }
}
