using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QGamePausePanel : MonoBehaviour
{
    void OnEnable()
    {
        Time.timeScale = 0; //일시정지
    }

    public void ResumeButtonClicked()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void GoMainButtonClicked()
    {
        //메인으로 scene 전환 코드
        Debug.Log("GoMainButton 클릭");
    }

    public void SettingClicked()
    {
        //메인 창 띄우기
        Debug.Log("Main 버튼 클릭");
    }
}
