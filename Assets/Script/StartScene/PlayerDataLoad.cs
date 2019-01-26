using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataLoad
{
    public static PlayerData playerdata;

    public class PlayerData
    {
        private int MaxScore; //최고점수
        private int AchievementIndex; //칭호(?) 열리는거
        private int SushiIndex; //스시 언락하는거

        private int coin; //사용자코인보유
        private int itemTurtle;
        private int itemLuckyCat;
        private int itemSoup;

        private static string []AchievementString =
            {"칭호1", "칭호2", "칭호3", "칭호4"}; //칭호 문자열
        private static int[] AchievementScore =
            {0,1000,2000,3000}; //칭호 언락 기준 점수

        //초기 데이터 생성, 사용자가 첫 게임 시작 한번만.
        public PlayerData()
        {
            MaxScore = 0;
            AchievementIndex = 0;
            SushiIndex = -1;
            coin = 0;
            itemTurtle = 0;
            itemLuckyCat = 0;
            itemSoup = 0;
        }

        public bool IsMaxScore(int newscore)
        {
            if (newscore > MaxScore)
            {
                MaxScore = newscore;
                return true;
            }
            else return false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerdata = new PlayerData();
    }

}
