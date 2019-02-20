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
    public GameObject MaxScoreText, MaxGuestText, MaxPlateText, MaxSushiText;

    private GameObject []StarArray;
    private int achievementStar;

    static String sName;
    private TouchScreenKeyboard keyboard;

    void Awake()
    {
        achievementStar = -1;
        StarArray = new GameObject[5];
        for (int i = 0; i < 5; i++)
            StarArray[i] = StarSystem.transform.GetChild(i).gameObject;
    }

    void Update()
    {
        storeName.GetComponent<Text>().text = sName;
        storeName_nameedit.GetComponent<Text>().text = sName;

        if (TouchScreenKeyboard.visible) {
            sName = keyboard.text;
        }
    }

    void OnEnable()
    {
        LoadStoreName();
        LoadAchievement();
        LoadMaxScores();
    }

    public void LoadMaxScores()
    {
        MaxScoreText.GetComponent<Text>().text = PlayerDataLoad.playerdata.MaxScore.ToString()+"점";
        MaxGuestText.GetComponent<Text>().text = PlayerDataLoad.playerdata.MaxGuest.ToString()+"명";
        MaxPlateText.GetComponent<Text>().text = PlayerDataLoad.playerdata.MaxPlate.ToString()+"개";
        MaxSushiText.GetComponent<Text>().text = PlayerDataLoad.playerdata.MaxSushi.ToString()+"개";

    }

    public void LoadStoreName()
    {
        try
        {
            sName = PlayerDataLoad.playerdata.storeName;
            String temp = PlayerDataLoad.playerdata.storeName;
            //String temp = sName;
            //int fontSize_temp = 880 / temp.Length;
            //storeName.GetComponent<Text>().fontSize = fontSize_temp;
            storeName.GetComponent<Text>().text = temp;
            //storeName_nameedit.GetComponent<Text>().fontSize = fontSize_temp;
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
            Achievement_nameedit.GetComponent<Text>().text = "\""+temp+"\""; //NameEdit패널 칭호 변경
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

    

    public void ReviseText() {
        
            keyboard = 
            TouchScreenKeyboard.Open
            (sName, TouchScreenKeyboardType.Default, true, false,false,false,"새로운 가게 이름을 입력하세요",10);
        keyboard.text = "";
        /*
        if (keyboard.text != null && !TouchScreenKeyboard.visible)
            {
            sName = keyboard.text;
            }
        */

    }

    public void NameEditPanel_XButtonClicked()
    {
        NameEditPanel.SetActive(false);

        PlayerDataLoad.playerdata.storeName = sName;
        PlayerDataLoad.SaveData();
    }
}
