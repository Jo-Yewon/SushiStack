using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    public GameObject CutArrayObject;
    public bool isTypingSkip;

    private int HowMuchCut;
    private int CurrentCutNum;
    private GameObject []CutArray;
    private Touch tempTouchs;

    void Start()
    {
        CurrentCutNum = 0;
        isTypingSkip = false;

        //CutArray에 컷 순서대로 담기
        HowMuchCut = CutArrayObject.transform.childCount;
        CutArray = new GameObject[HowMuchCut];
        for (int i = 0; i < HowMuchCut; i++)
            CutArray[i] = CutArrayObject.transform.GetChild(i).gameObject;

        GameObject.FindWithTag("SoundManager").GetComponent<BGMScript>().IntroBGMPlay();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                tempTouchs = Input.GetTouch(i);
                if (tempTouchs.phase == TouchPhase.Ended)
                {
                    if (isTypingSkip == false) isTypingSkip = true; //첫번째 터치는 자막 타이핑 효과만 스킵
                    else
                    {
                        if (++CurrentCutNum >= HowMuchCut)
                            SceneManager.LoadScene("MainScene"); //마지막 인트로 컷이었다면, 메인신으로 이동.
                        else
                        {
                            gameObject.GetComponent<AudioSource>().Play();
                            isTypingSkip = false;
                            CutArray[CurrentCutNum - 1].SetActive(false); //현재 컷 멈추기
                            CutArray[CurrentCutNum].SetActive(true); //다음 컷 띄우기
                        }
                    }
                }
            }
        }

    }

    public void SkipButtonClicked() //스킵버튼과 연결되어 있음
    {
        gameObject.GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("MainScene");
    }
}
