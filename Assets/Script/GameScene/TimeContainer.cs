using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeContainer : MonoBehaviour
{
    public GameObject stageCutton;

    private Animation stageCuttonAnim;

    void Awake()
    {
        stageCuttonAnim = stageCutton.GetComponent<Animation>();
    }

    void Start()
    {
        Time.timeScale = 1;
    }

    void StageCuttonDownUP()
    {
        stageCuttonAnim.Play("StageCuttonDownAnim");
    }

    void InitStage()
    {
        Debug.Log("StageInit");
        //(다음 고양이 random으로 고르고 disable->enable 할 예정);
    }
}
