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
    public static bool isFirst;

    [Serializable]
    public class PlayerData
    {
        //게임 시작하면 위 필드에 playerdata 변수에 사용자 정보가 인스턴스로 담깁니다.
        //static 설정 필요 없이 위 playerdata의 인스턴스 변수에 접근하면 됩니다!
        //모든 신에서 PlayerDataLoad.playerdata.(필드이름)으로 접근하여 수정한후
        //PlayerDataLoad.playerdata.SaveData()를 하면 자동으로 로컬기기에 파일로 저장됩니다.
        public int MaxScore; //최고점수
        public int MaxSushi; //최고초밥 기록
        public int MaxGuest; //최고 손님수 기록
        public int MaxPlate; //최고 접시수 기록

        public int LastAchievementIndex;
        public int AchievementIndex; //칭호(?) 열리는거
        public readonly static string []AchievementString =
            {"길냥이", "견습생 고양이", "초보 요리사", "숙련된 요리사",
        "초보 주방장","숙련된 주방장", "오성급 쉐프","스타 쉐프", "초밥 장인", "초밥왕"}; //칭호 문자열
        public readonly static int[] AchievementScore =
            {0,1000,2000,3000,4000,5000,6000,7000,8000,9000,}; //칭호 언락 기준 점수

        public int coin;
        public int item_luckycat_num; //행운의 고양이 개수
        public String storeName;

        //초기 데이터 생성, 사용자가 첫 게임 시작 한번만.
        public PlayerData()
        {
            MaxScore = 0;
            MaxSushi = 0;
            MaxGuest = 0;
            AchievementIndex = 0;
            coin = 0;
            item_luckycat_num = 0;
            storeName = "클릭해보세요!";
        }
        
        public bool IsMaxScore(int newScore)
        {
            if (newScore > MaxScore) return true;
            return false;
        }

        public int IsMaxScoreIsUnlock(int newscore, int newSushiScore, int newGuestScore, int newPlateScore)
        {
            //return -1 : 신기록 경신X.
            //return 0 : 신기록은 경신되었으나, 새로운 칭호는 언락되지 않음.
            //return n : 신기록이 경신되었으며, AchievementIndex가 n으로 높아짐.

            if (newSushiScore > MaxSushi) MaxSushi = newSushiScore;
            if (newGuestScore > MaxGuest) MaxGuest = newGuestScore;
            if (newPlateScore > MaxPlate) MaxPlate = newPlateScore;

            if (newscore > MaxScore) MaxScore = newscore;
            else return -1; //신기록 경신 안함

            int i;
            for(i = AchievementIndex + 1; i < 10; i++)
                if (newscore < AchievementScore[i]) break;

            if (i == AchievementIndex + 1) return 0; //신기록은 경신되었으나 새로운 칭호는 X

            LastAchievementIndex = AchievementIndex; //갱신 전 인덱스 따로 저장
            AchievementIndex = (i - 1); //칭호 인덱스 갱신
            return AchievementIndex;
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
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

            bf.Serialize(file, playerdata);
            file.Close();
        }catch (Exception e)
        {
            Debug.Log(e.Message + "\n사용자 데이터를 저장하는데 오류가 발생.");
        }
    }

    //사용자가 첫 접속인 경우에는 true 반환, 그렇지 않을때는 false 반환
    public bool LoadData()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);

            if (file != null && file.Length > 0) //기존 데이터가 존재할 경우
                playerdata = (PlayerData)bf.Deserialize(file);
            return false;

        }
        catch (FileNotFoundException e) //첫 접속이어서 데이터가 존재하지 않을 경우,
        {
            playerdata = new PlayerData();
            return true;

        } catch (Exception e)
        {
            Debug.Log(e.Message + "\n사용자 데이터를 읽어오는데 오류가 발생");
            return false;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        isFirst=LoadData();
        GameObject.FindWithTag("SoundManager").gameObject.GetComponent<BGMScript>().StartBGMPlay(); //시작 노래 틀기
    }
}
