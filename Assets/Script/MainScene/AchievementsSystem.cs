#pragma warning disable 0168

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementsSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        AchievementUpdate();
    }

    public void AchievementUpdate()
    {
        try
        {
            gameObject.GetComponent<Text>().text = PlayerDataLoad.PlayerData.AchievementString[PlayerDataLoad.playerdata.AchievementIndex];
        }
        catch (Exception e) { }
    }
}
