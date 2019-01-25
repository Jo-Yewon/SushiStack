using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeContainer : MonoBehaviour
{
    public GameObject stageCutton;

    private Animation timeContainerAnim;
    private Animation stageCuttonAnim;

    void Awake()
    {
        timeContainerAnim = gameObject.GetComponent<Animation>();
        stageCuttonAnim = stageCutton.GetComponent<Animation>();
    }

    void Start()
    {
        Debug.Log("Start");
        timeContainerAnim.Play("TimeContainerAnim"); //애니메이션 다시 재생이 안돼여,,
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
