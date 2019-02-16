using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#pragma warning disable 0168

public class Timer30s : MonoBehaviour
{
    public Slider left, right;
    public GameObject stageCutton;
    public GameObject OrderPanel;
    public GameObject GameManager;
    public static int GuestScore, ThiefCatCount;
    public GameObject GuestScoreObject;
    public GameObject CatObject;
    public GameObject TheifCatPanel;
    public GameObject TheifCatObject;
    public GameObject TheifSucceedPop, ThiefFailedPop;
    public GameObject CatSoundObj, TheifCatSoundObj;

    //<상수필드>
    private static readonly float PER_SECOND = 0.03333333f; // 1나누기30(초)
    private static readonly float THIEF_CAT_PROB = 0.2f; //도둑고양이 출현 확률
    private static readonly int CAT_SPRITE_NUM = 8; //고양이 종류
    private static readonly float THIEF_CAT_TIME = 5f; //도둑고양이 5초동안
    private static readonly int THIEF_TOUCH_TIME = 10; //도둑고양이 10번 터치

    private Animation CatObjAnim;
    private Animation cuttonDownAnim;
    private List<GameObject> orderArray; /// order들이 배열로 담김.
    private Transform orderPanel_Transform;
    private int currentModeNum;
    private Text GuestScoreText;
    private SpriteRenderer CatImageComponent;
    private Animation TheifCatAnim;

    void Awake()
    {
        try
        {
            //게임 배경 음악 틀기
            GameObject.FindWithTag("SoundManager").GetComponent<BGMScript>().GameBGMPlay();
        }catch (Exception e) {        }
    }

    void Start()
    {
        //order배열 생성
        orderPanel_Transform = OrderPanel.transform;
        orderArray = new List<GameObject>();
        for (int i = 0; i < OrderPanel.transform.childCount; i++)
            orderArray.Add(orderPanel_Transform.GetChild(i).gameObject);

        cuttonDownAnim = stageCutton.GetComponent<Animation>();
        CatObjAnim = CatObject.GetComponent<Animation>();
        TheifCatAnim = TheifCatObject.GetComponent<Animation>();
        CatImageComponent = CatObject.GetComponent<SpriteRenderer>();

        StartCoroutine("TimeCount");
        GuestScore = 0; //게임 시작시 static 변수 초기화
        ThiefCatCount = 0;
        GuestScoreText = GuestScoreObject.GetComponent<Text>();
    }

    IEnumerator TimeCount()
    {
        yield return new WaitForSeconds(0.1f);

        if (UnityEngine.Random.Range(0.0f, 1.0f) <THIEF_CAT_PROB) //20퍼 확률로 도둑고양이
        {
            yield return StartCoroutine("ThiefCatMiniGame");
        }

        CatImageChange();
        //고양이 올리기
        CatObjAnim.Play("CatUp");
        CatSoundObj.GetComponent<AudioSource>().Play(); //고양이 등장 소리
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
            left.value -= PER_SECOND;
            right.value -= PER_SECOND;
        }

        cuttonDownAnim.Play("CuttonDown");
        CatObjAnim.Play("CatDown"); //고양이 내려감
        GameManager.SetActive(false);
        GuestScoreUpdate();
        StartCoroutine("TimeCount");
    }

    IEnumerator ThiefCatMiniGame() //도둑고양이 미니게임
    {
        TheifCatPanel.SetActive(true);
        TheifCatObject.GetComponent<Button>().interactable = true;
        TheifCatAnim.Play("ThiefCatUp");
        CatSoundObj.GetComponent<AudioSource>().Play(); //도둑 고양이 등장 소리

        yield return new WaitForSeconds(THIEF_CAT_TIME);
        if (TheifCat.touchCount < THIEF_TOUCH_TIME) //실패했을때
        {
            ThiefFailedPop.SetActive(true);
            TheifCatObject.GetComponent<Image>().sprite= (Sprite)Resources.Load("thiefCatRun", typeof(Sprite));
            TheifCatAnim.Play("ThiefCatRun");

            yield return new WaitForSeconds(TheifCatAnim["ThiefCatRun"].length);
            TheifCatObject.GetComponent<Image>().sprite = (Sprite)Resources.Load("0", typeof(Sprite));
            yield return new WaitForSeconds(0.3f);
            ThiefFailedPop.SetActive(false);
            yield return new WaitForSeconds(0.6f);
        }
        else { //성공했을때
            TheifSucceedPop.SetActive(true);
            TheifCatObject.GetComponent<Button>().interactable= false; //퇴치 성공시 울상으로 바뀌고
            TheifCatAnim.Play("ThiefCatCry");
            TheifCatSoundObj.GetComponent<AudioSource>().Play(); //유는 고양이 소리
            yield return new WaitForSeconds(TheifCatAnim["ThiefCatCry"].length);

            ThiefCatCount++;

            TheifCatAnim.Play("ThiefCatDown"); //내려가기
            yield return new WaitForSeconds(TheifCatAnim["ThiefCatDown"].length);
            TheifSucceedPop.SetActive(false);
            yield return new WaitForSeconds(0.6f);

        }
        TheifCatPanel.SetActive(false);
    }

    void SelectMode() //Mode를 랜덤하게 선택한 후, 말풍선 띄우는 함수
    {
        currentModeNum = UnityEngine.Random.Range(0, orderPanel_Transform.childCount);
        orderArray[currentModeNum].SetActive(true);
    }

    void GuestScoreUpdate()
    {
        GuestScore++;
        GuestScoreText.text = GuestScore.ToString();
    }

    void CatImageChange() //고양이 이미지 변경
    {
        int temp = UnityEngine.Random.Range(1, CAT_SPRITE_NUM);
        CatImageComponent.sprite = (Sprite)Resources.Load("UserCat/" + temp, typeof(Sprite));
    }
}
