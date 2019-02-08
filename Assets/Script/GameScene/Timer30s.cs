using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer30s : MonoBehaviour
{
    public Slider left, right;
    public GameObject stageCutton;
    public GameObject OrderPanel;
    public GameObject GameManager;
    public int GuestScore;
    public GameObject GuestScoreObject;

    private Animation cuttonDownAnim;
    private static float perSecond=0.03333333f;
    private List<GameObject> orderArray; /// order들이 배열로 담김.
    private Transform orderPanel_Transform;
    private int currentModeNum;
    private Text GuestScoreText;

    void Start()
    {
        //order배열 생성
        orderPanel_Transform = OrderPanel.transform;
        orderArray = new List<GameObject>();
        for (int i = 0; i < OrderPanel.transform.childCount; i++)
            orderArray.Add(orderPanel_Transform.GetChild(i).gameObject);

        cuttonDownAnim = stageCutton.GetComponent<Animation>();

        StartCoroutine("TimeCount");
        GuestScore = 0;
        GuestScoreText = GuestScoreObject.GetComponent<Text>();
    }

    IEnumerator TimeCount()
    {
        InitStage();//스테이지 초기화 함수

        yield return new WaitForSeconds(2f);//2초 후
        cuttonDownAnim.Play("CuttonUp");
        GameManager.SetActive(true);
        orderArray[currentModeNum].SetActive(false); //주문 말풍선 감추기

        left.value = 1;
        right.value = 1;
        for (int i = 0; i < 30; i++) //30초동안 세기
        {
            yield return new WaitForSeconds(1f);
            left.value -= perSecond;
            right.value -= perSecond;
        }

        cuttonDownAnim.Play("CuttonDown");
        GuestScoreUpdate();
        StartCoroutine("TimeCount");
    }

    public void InitStage()
    {
        GameManager.SetActive(false);
        SelectMode();
    }

    public void SelectMode() //Mode를 랜덤하게 선택하는 함수
    {
        currentModeNum = Random.Range(0, orderPanel_Transform.childCount);
        orderArray[currentModeNum].SetActive(true);
    }

    public void GuestScoreUpdate()
    {
        GuestScore++;
        GuestScoreText.text = GuestScore.ToString();
    }
   

}
