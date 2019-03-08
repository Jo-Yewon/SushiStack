using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager1 : MonoBehaviour
{
    public void GoMain()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ChangeTo1()
    {
        PlayerDataLoad.playerdata.AchievementIndex = 1;
        PlayerDataLoad.SaveData();
    }

    public void ChangeTo2()
    {
        PlayerDataLoad.playerdata.AchievementIndex = 2;
        PlayerDataLoad.SaveData();
    }

    public void ChangeTo3()
    {
        PlayerDataLoad.playerdata.AchievementIndex = 3;
        PlayerDataLoad.SaveData();
    }

    public void ChangeTo4()
    {
        PlayerDataLoad.playerdata.AchievementIndex = 4;
        PlayerDataLoad.SaveData();
    }

    public void ChangeTo5()
    {
        PlayerDataLoad.playerdata.AchievementIndex = 5;
        PlayerDataLoad.SaveData();
    }

    public void ChangeTo7()
    {
        PlayerDataLoad.playerdata.AchievementIndex = 7;
        PlayerDataLoad.SaveData();
    }

    public void ChangeTo8()
    {
        PlayerDataLoad.playerdata.AchievementIndex = 8;
        PlayerDataLoad.SaveData();
    }

    public void ChangeTo9()
    {
        PlayerDataLoad.playerdata.AchievementIndex = 9;
        PlayerDataLoad.SaveData();
    }

    public void ChangeTo6()
    {
        PlayerDataLoad.playerdata.AchievementIndex = 6;
        PlayerDataLoad.SaveData();
    }

    public void CoinPlus()
    {
        PlayerDataLoad.playerdata.coin += 1000;
        PlayerDataLoad.SaveData();
    }

    public void LuckyCatPlus()
    {
        PlayerDataLoad.playerdata.item_luckycat_num += 10;
        PlayerDataLoad.SaveData();

    }
}
