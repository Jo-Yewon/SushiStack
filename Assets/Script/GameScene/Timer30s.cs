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
    public GameObject CatObject;

    private Animation cuttonDownAnim;
    private static float perSecond=0.03333333f; // 1나누기30(초)
    private List<GameObject> orderArray; /// order들이 배열로 담김.
    private Transform orderPanel_Transform;
    private int currentModeNum;
    private Text GuestScoreText;
    private static float thiefCatProbability = 0.2f; //도둑고양이 출현 확률
    private Animation CatObjAnim;
    private SpriteRenderer CatImageComponent;
    private static int CatSpriteNum = 8;
    private static int TheifScore;

    void Start()
    {
        //order배열 생성
        orderPanel_Transform = OrderPanel.transform;
        orderArray = new List<GameObject>();
        for (int i = 0; i < OrderPanel.transform.childCount; i++)
            orderArray.Add(orderPanel_Transform.GetChild(i).gameObject);

        cuttonDownAnim = stageCutton.GetComponent<Animation>();
        CatObjAnim = CatObject.GetComponent<Animation>();
        CatImageComponent = CatObject.GetComponent<SpriteRenderer>();

        StartCoroutine("TimeCount");
        GuestScore = 0;
        GuestScoreText = GuestScoreObject.GetComponent<Text>();
    }

    IEnumerator TimeCount()
    {
        yield return new WaitForSeconds(0.1f);

        if (CatImageChange(true) == 0)
        {
            yield return StartCoroutine("ThiefCatMiniGame");
            ThiefScoreUpdate();
            CatImageChange(false);
        }

        //고양이 올리기
        CatObjAnim.Play("CatUp");
        yield return new WaitForSeconds(0.1f);
        SelectMode(); //모드 선택 및 말풍선

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
        CatObjAnim.Play("CatDown"); //고양이 내려감
        GameManager.SetActive(false);
        GuestScoreUpdate();
        StartCoroutine("TimeCount");
    }

    IEnumerator ThiefCatMiniGame() //도둑고양이 미니게임
    {
        CatObjAnim.Play("CatUp");
        Debug.Log("Theif");
        yield return new WaitForSeconds(3f);
        CatObjAnim.Play("CatDown");
        yield return new WaitForSeconds(3f);

    }

    void SelectMode() //Mode를 랜덤하게 선택한 후, 말풍선 띄우는 함수
    {
        currentModeNum = Random.Range(0, orderPanel_Transform.childCount);
        orderArray[currentModeNum].SetActive(true);
    }

    void GuestScoreUpdate()
    {
        GuestScore++;
        GuestScoreText.text = GuestScore.ToString();
    }

    void ThiefScoreUpdate()
    {
        TheifScore++;
        //상단 Score 표시도 업데이트하는 코드
    }

    int CatImageChange(bool istheifYes) //고양이 이미지 변경
    {
        int temp;

            if (istheifYes)
            {
                if (Random.Range(0.0f, 1.0f) < thiefCatProbability) temp = 0; //도둑고양이
                else temp = Random.Range(1, CatSpriteNum);
            }
            else
            {
                temp = Random.Range(1, CatSpriteNum);
            }

        CatImageComponent.sprite = (Sprite)Resources.Load("UserCat/" + temp, typeof(Sprite));
        return temp;
    }
}
