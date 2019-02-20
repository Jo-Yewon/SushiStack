using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QResultPanel : MonoBehaviour
{
    public GameObject redPlateText, greenPlateText, bluePlateText;
    public GameObject GuestScoreText, ThiefScoreText;
    public GameObject TimeManager;
    public GameObject SushiScoreText, TotalScoreText, TotalCoinText;
    public GameObject IngameScoreText;
    public GameObject MaxScoreText;
    public GameObject NewAchieveSushiPanel, NewAchieveOnlyPanel;
    // Start is called before the first frame update

    void OnEnable()
    {
        int totalScore, sushiNumScore, guestNumScore, plateNumScore, coin;

        //접시 개수 표시하기
        redPlateText.GetComponent<Text>().text = RedPlate.redPlateNum.ToString();
        greenPlateText.GetComponent<Text>().text = GreenPlate.greenPlateNum.ToString();
        bluePlateText.GetComponent<Text>().text = BluePlate.bluePlateNum.ToString();
        plateNumScore = RedPlate.redPlateNum + GreenPlate.greenPlateNum + BluePlate.bluePlateNum;//총 접시 개수

        //스시 개수 표시하기
        //sushiNumScore=...
        sushiNumScore = 0; //임시로해놓음

        //손님 수, 도둑고양이 성공수 표시
        GuestScoreText.GetComponent<Text>().text = Timer30s.GuestScore.ToString();
        ThiefScoreText.GetComponent<Text>().text = Timer30s.ThiefCatCount.ToString();
        guestNumScore = Timer30s.GuestScore;//손님 수
        TimeManager.SetActive(false);

        //점수 및 코인 표시
        totalScore = Int32.Parse(IngameScoreText.GetComponent<Text>().text); //점수를 저장
        TotalScoreText.GetComponent<Text>().text = totalScore.ToString(); //결과창에 점수 표시
        coin = totalScore * 5; //코인 계산
        TotalCoinText.GetComponent<Text>().text = coin.ToString(); //결과창에 코인 표시
        PlayerDataLoad.playerdata.coin += coin; //코인 획득

        //점수 갱신 및 칭호, 초밥 언락 확인
        int LastIndex = PlayerDataLoad.playerdata.AchievementIndex;
        int NewIndex = PlayerDataLoad.playerdata.IsMaxScoreIsUnlock(totalScore, sushiNumScore, guestNumScore, plateNumScore);
        if (NewIndex != -1) //신기록 갱신한경우
        {
            MaxScoreText.SetActive(true);
            if(NewIndex != 0) //새로운 칭호 언락 된 경우
            {
                if ((NewIndex - LastIndex) == 1 && (((NewIndex == 3) || (NewIndex == 6))||( NewIndex == 9)))
                {
                    NewAchieveOnlyPanel.SetActive(true); //초밥 언락 없이 칭호만 열림
                }
                else NewAchieveSushiPanel.SetActive(true); //초밥과 칭호가 모두 언락됨.
            }
        }
        PlayerDataLoad.SaveData();//새로 갱신된 정보 파일로 저장하기.
    }

    public void RetryButtonClick()
    {
        GameObject.FindWithTag("SoundManager").GetComponent<BGMScript>().ButtonClickedSoundPlay();
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }

    public void HomeButtonClick()
    {
        GameObject.FindWithTag("SoundManager").GetComponent<BGMScript>().ButtonClickedSoundPlay();
        Time.timeScale = 1;
        SceneManager.LoadScene("MainScene");
    }
}