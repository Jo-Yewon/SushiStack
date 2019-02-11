#pragma warning disable 0168

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementStoreManager : MonoBehaviour
{
    public GameObject storeName;
    public GameObject storeName_nameedit;
    public GameObject Achievement;
    public GameObject Achievement_nameedit;
    public GameObject StarSystem;
    public GameObject NameEditPanel;

    private GameObject []StarArray;
    private int achievementStar;

    void Awake()
    {
        achievementStar = -1;
        StarArray = new GameObject[5];
        for (int i = 0; i < 5; i++)
            StarArray[i] = StarSystem.transform.GetChild(i).gameObject;
    }

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
            int fontSize_temp = 880 / temp.Length;
            storeName.GetComponent<Text>().fontSize = fontSize_temp;
            storeName.GetComponent<Text>().text = temp;
            storeName_nameedit.GetComponent<Text>().fontSize = fontSize_temp;
            storeName_nameedit.GetComponent<Text>().text = temp;
        }
        catch (Exception e) { }
    }

    public void LoadAchievement()
    {
        try
        {
            int achieveIndex = PlayerDataLoad.playerdata.AchievementIndex;
            String temp = PlayerDataLoad.PlayerData.AchievementString[achieveIndex];

            Achievement.GetComponent<Text>().text = temp; //현판 칭호 변경
            Achievement_nameedit.GetComponent<Text>().text = temp; //NameEdit패널 칭호 변경
            Achievement_nameedit.GetComponent<AchivementCase>().ResizeQuotes();

            //별 개수 변경
            achieveIndex /= 2;
            if (achievementStar != -1)
                StarArray[achievementStar].SetActive(false);
            StarArray[achieveIndex].SetActive(true);
            achievementStar = achieveIndex;
        }
        catch (Exception e) {
            Debug.Log(e.Message);
        }
    }

    public void NameEditPanel_XButtonClicked()
    {
        NameEditPanel.SetActive(false);
    }
}
