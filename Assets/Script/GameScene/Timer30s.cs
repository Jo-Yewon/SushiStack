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

    // Start is called before the first frame update
    void Start()
    {
        cuttonDownAnim = stageCutton.GetComponent<Animation>();
        StartCoroutine("TimeCount");
    }

    IEnumerator TimeCount()
    {
        for(int i = 0; i < 30; i++)
        {
            yield return new WaitForSeconds(1f);
            left.value += perSecond;
            right.value += perSecond;
        }
        cuttonDownAnim.Play(); //커튼 내려오기
        left.value = 0;
        right.value = 0;
        cuttonDownAnim.Play("StageCuttonUp");
        InitStage();
        StartCoroutine("TimeCount");
    }

    public void InitStage()
    {
        Debug.Log("InitStage()");
    }

}
