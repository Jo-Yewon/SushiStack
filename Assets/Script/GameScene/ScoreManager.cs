using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public GameObject ScoreTextObject;
    public GameObject MaxScoreDeco, Score50DownDeco;
    public GameObject getSound;

    private Text scoreText;
    private int total_score;
    private int maxScore;

    public void Start()
    {
        scoreText = ScoreTextObject.GetComponent<Text>();
        total_score = 0;
        maxScore = PlayerDataLoad.playerdata.MaxScore;
    }

    //외부에서 호출.
   public void ScoreUp(int score)
    {
        getSound.GetComponent<AudioSource>().Play();
        total_score += score; //피버모드이면 2배해서 더하도록 수정
        scoreText.text = total_score.ToString();

        if (score > maxScore) //신기록 경신시 데코
            if (MaxScoreDeco.activeSelf == false)
                MaxScoreDeco.SetActive(true);
    }

    //도둑고양이 실패시 50퍼 까임
    public void ThiefFailed()
    {
        Score50DownDeco.SetActive(true);
        total_score /= 2;
        scoreText.text = total_score.ToString();

        if (MaxScoreDeco.activeSelf == true)//신기록 이었는데
            if (total_score <= maxScore) //50퍼 까여서 신기록 취소되면
                MaxScoreDeco.SetActive(false); //Max 표시 다시 없애기.
    }
}
