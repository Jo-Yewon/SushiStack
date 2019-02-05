#pragma warning disable 0168

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDataLoad : MonoBehaviour
{
    public static PlayerData playerdata; //게임 전체에서 PlayerData가 담기는 곳.

    [Serializable]
    public class PlayerData
    {
        public int MaxScore; //최고점수
        public int MaxSushi;
        public int MaxGuest;

        public int AchievementIndex; //칭호(?) 열리는거
        public static string []AchievementString =
            {"칭호1", "칭호2", "칭호3", "칭호4"}; //칭호 문자열
        public static int[] AchievementScore =
            {0,1000,2000,3000}; //칭호 언락 기준 점수

        public int coin;

        public int item_luckycat_num;

        //초기 데이터 생성, 사용자가 첫 게임 시작 한번만.
        public PlayerData()
        {
            MaxScore = 0;
            AchievementIndex = 0;
            coin = 0;
            item_luckycat_num = 0;
        }

        public bool IsMaxScore(int newscore)
        {
            //기존 최고기록 경신된다면, true 반환
            if (newscore > MaxScore)
            {
                MaxScore = newscore;
                return true;
            }
            else return false;
        }

        public bool IsUnlockAchievement(int newscore)
        {
            //다음 칭호 unlock 조건에 부합하면 unlock 후 true 반환
            if (newscore> AchievementScore[AchievementIndex + 1])
            {
                AchievementIndex++;
                return true;
            }
            return false;
        }
    }

    public static void SaveData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        bf.Serialize(file, playerdata);
        file.Close();
    }

    public void LoadData()
    {
        try { 
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat",FileMode.Open);

        if (file != null && file.Length > 0) //기존 데이터가 존재할 경우
                playerdata = (PlayerData)bf.Deserialize(file);
        }catch(Exception e) //첫 접속일 경우
        {
            playerdata = new PlayerData();
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        LoadData();
    }
}
