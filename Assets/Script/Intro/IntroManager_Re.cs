using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager_Re : MonoBehaviour
{
    public GameObject CutArrayObject_re;
    public bool isTypingSkip_re;

    private int HowMuchCut_re;
    private int CurrentCutNum_re;
    private GameObject []CutArray_re;
    private Touch tempTouchs_re;

    void Start()
    {
        CurrentCutNum_re = 0;
        isTypingSkip_re = false;

        //CutArray에 컷 순서대로 담기
        HowMuchCut_re = CutArrayObject_re.transform.childCount;
        CutArray_re = new GameObject[HowMuchCut_re];
        for (int i = 0; i < HowMuchCut_re; i++)
            CutArray_re[i] = CutArrayObject_re.transform.GetChild(i).gameObject;

        GameObject.FindWithTag("SoundManager").GetComponent<BGMScript>().IntroBGMPlay();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                tempTouchs_re = Input.GetTouch(i);
                if (tempTouchs_re.phase == TouchPhase.Ended)
                {
                    if (isTypingSkip_re == false) isTypingSkip_re = true; //첫번째 터치는 자막 타이핑 효과만 스킵
                    else
                    {
                        if (++CurrentCutNum_re >= HowMuchCut_re)
                        {
                            SceneManager.LoadScene("MainScene"); //마지막 인트로 컷이었다면, 메인신으로 이동.
                        }
                        else
                        {
                            gameObject.GetComponent<AudioSource>().Play();
                            isTypingSkip_re = false;
                            CutArray_re[CurrentCutNum_re - 1].SetActive(false); //현재 컷 멈추기
                            CutArray_re[CurrentCutNum_re].SetActive(true); //다음 컷 띄우기
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
