using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NamingManager : MonoBehaviour
{
    public GameObject text1, text2, text3, text4, button1, button2;
    public GameObject GuestTutorialPanel;

    private String sName;
    private TouchScreenKeyboard keyboard;
    private bool isNameSetEnd, isUpdate;
    private readonly static float INTERVAL_TIME=1f;
    private Touch tempTouchs;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindWithTag("SoundManager").GetComponent<BGMScript>().TutorialBGMPlay();
        //isTestTouch = false;
        isUpdate = true;
        isNameSetEnd = false;
        StartCoroutine("NamingCoroutine");
    }

    void Update()
    {
        if (isUpdate)
        {
            if (TouchScreenKeyboard.visible)
            {
                sName = keyboard.text;
            }
            else if (isNameSetEnd)
            {
                isUpdate = false;
                StartCoroutine("NameEndCoroutine");
            }
        }
        /*
        if (isTestTouch)
        {
            if (Input.touchCount > 0)
            {
                tempTouchs = Input.GetTouch(0);
                if (tempTouchs.phase == TouchPhase.Ended)
                {
                    GuestTutorialPanel.SetActive(true);
                    gameObject.SetActive(false);
                }
            }
        }
        */
    }

    IEnumerator NamingCoroutine()
    {
        text1.SetActive(true);
        yield return new WaitForSeconds(INTERVAL_TIME);
        text2.SetActive(true);
        yield return new WaitForSeconds(INTERVAL_TIME);
        button1.SetActive(true);
    }

    IEnumerator NameEndCoroutine()
    {
        try
        {
            //사용자가 입력한 이름 저장
            PlayerDataLoad.playerdata.storeName = sName;
            PlayerDataLoad.SaveData();
        }
        catch (Exception e) { }

        //잘했어요로 넘어가기
        text1.SetActive(false);
        text2.SetActive(false);
        button1.SetActive(false);
        text3.SetActive(true);
        yield return new WaitForSeconds(INTERVAL_TIME);
        text4.GetComponent<Text>().text = "<" + sName + "> 오픈을 축하드립니다!";
        text4.SetActive(true);
        yield return new WaitForSeconds(INTERVAL_TIME);
        //isTestTouch = true;
        button2.SetActive(true); //다음 버튼 보이게
    }

    public void NameButtonClicked()
    {
        keyboard =
            TouchScreenKeyboard.Open
            (sName, TouchScreenKeyboardType.Default, true, false, false, false, "새로운 가게 이름을 입력하세요", 10);
        keyboard.text = "";
        isNameSetEnd = true;
    }

    public void TempButtonClicked()
    {
        sName = "내 가게";
        isNameSetEnd = true;
    }

    public void NextButtonClicked()
    {
        GuestTutorialPanel.SetActive(true);
        gameObject.SetActive(false);
    }
}
