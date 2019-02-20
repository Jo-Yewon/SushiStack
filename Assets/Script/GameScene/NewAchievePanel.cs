using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewAchievePanel : MonoBehaviour
{
    public GameObject NewAchieveText;

    void Update()
    {
        Time.timeScale = 1;
    }

    void OnEnable()
    {
        //새롭게 획득한 칭호 표시 //다수의 칭호를 동시에 획득시 가장 높은 칭호만 표시하기.
        NewAchieveText.GetComponent<Text>().text =
            PlayerDataLoad.PlayerData.AchievementString[PlayerDataLoad.playerdata.AchievementIndex];
    }

    public void OKClicked() //화면 누르면 다시 결과창으로 돌아가기
    {
        gameObject.SetActive(false);
    }
}
