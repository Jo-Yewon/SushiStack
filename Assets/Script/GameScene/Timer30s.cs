using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer30s : MonoBehaviour
{
    public Slider left, right;
    public GameObject stageCutton;

    private Animation cuttonDownAnim;
    
    private static float perSecond=0.03333333f;

    void Start()
    { 
        cuttonDownAnim = stageCutton.GetComponent<Animation>();
        StartCoroutine("TimeCount");
    }

    IEnumerator TimeCount()
    {
        left.value = 1;
        right.value = 1;
        for (int i = 0; i < 30; i++)
        {
            yield return new WaitForSeconds(1f);
            left.value -= perSecond;
            right.value -= perSecond;
        }
        cuttonDownAnim.Play("CuttonDown");
        Invoke("NewRound", 1f); //1초 후에 커튼 올리기
        InitStage(); //스테이지 초기화 함수
    }

    public void NewRound()
    {
        cuttonDownAnim.Play("CuttonUp");
        StartCoroutine("TimeCount");
    }

    public void InitStage()
    {
        Debug.Log("InitStage()");
    }

}
