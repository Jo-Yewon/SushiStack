#pragma warning disable 0168

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementStoreManager : MonoBehaviour
{
    public GameObject storeName;
    public GameObject Achievement;

    // Start is called before the first frame update
    void OnEnable()
    {
        LoadStoreName();
        LoadAchievement();
    }

    public void LoadStoreName()
    {
        try
        {
            String temp = PlayerDataLoad.playerdata.storeName;
            storeName.GetComponent<Text>().fontSize = 880/ temp.Length;
            storeName.GetComponent<Text>().text = temp;
        }
        catch (Exception e) { }
    }

    public void LoadAchievement()
    {
        try
        {
            String temp = PlayerDataLoad.PlayerData.AchievementString[PlayerDataLoad.playerdata.AchievementIndex];
            Achievement.GetComponent<Text>().text = temp;
        }
        catch (Exception e) { }
    }
}
