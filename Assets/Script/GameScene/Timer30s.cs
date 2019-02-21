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
    public GameObject CatSoundObj, ThiefCatCry, ThiefCatLaugh;
    public GameObject TempItemArray;
    public GameObject ItemFallingObject;
    public GameObject ScoreManager;
    public GameObject SushiArrayObj;

    //<상수필드>
    private static readonly float PER_SECOND = 0.03333333f; // 1나누기30(초)
    private static readonly float THIEF_CAT_PROB = 0.2f; //도둑고양이 출현 확률
    private static readonly int CAT_SPRITE_NUM = 8; //고양이 종류
    private static readonly float THIEF_CAT_TIME = 5f; //도둑고양이 5초동안
    private static readonly int THIEF_TOUCH_TIME = 10; //도둑고양이 10번 터치
    private static readonly float infinite = 100f;

    private Animation CatObjAnim;
    private Animation cuttonDownAnim;
    private List<GameObject> orderArray; /// order들이 배열로 담김.
    private Transform orderPanel_Transform;
    private int currentModeNum;
    private SpriteRenderer CatImageComponent;
    private Animation TheifCatAnim;

    void Awake()
    {
        Time.timeScale = 1;
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

        TheifCatAnim = TheifCatObject.GetComponent<Animation>();
        CatImageComponent = CatObject.GetComponent<SpriteRenderer>();

        StartCoroutine("TimeCount");
        GuestScore = 0; //게임 시작시 static 변수 초기화
        ThiefCatCount = 0;
    }

    private void ClearPlate()
    {
        for (int i = TempItemArray.transform.childCount - 1; i >= 0; i--)
            GameObject.Destroy(TempItemArray.transform.GetChild(i).gameObject);
    }

    private void StopAndClearSushi()
    {
        /*
        Debug.Log("ClearSushi");
        GameObject[] GItem = GameObject.FindGameObjectsWithTag("itemgreen");
        GameObject[] BItem = GameObject.FindGameObjectsWithTag("itemblue");
        GameObject[] RItem = GameObject.FindGameObjectsWithTag("itemred");
        for (int i = 0; i < GItem.Length; i++)
        {
            Debug.Log(GItem[i].name + "을 초기화");
            GItem[i].GetComponent<SushiFalling>().timerFall = infinite;
        }
        for (int i = 0; i < BItem.Length; i++)
        {
            BItem[i].GetComponent<SushiFalling>().timerFall = infinite;
            Debug.Log(BItem[i].name + "을 초기화");
        }
        for (int i = 0; i < RItem.Length; i++)
        {
            RItem[i].GetComponent<SushiFalling>().timerFall = infinite;
            Debug.Log(BItem[i].name + "을 초기화");
        }*/

        for (int i = 0; i < 9; i++)
        {
            //SushiArrayObj.transform.GetChild(i).GetComponent<SushiFalling>().enabled=false;
            SushiArrayObj.transform.GetChild(i).localPosition = new Vector3(UnityEngine.Random.Range(-520f, 520f), 2550 / 2, 0);
        }

    }

    private void RedropSushi()
    {
        for (int i = 0; i < 9; i++)
        {
            SushiArrayObj.transform.GetChild(i).GetComponent<SushiFalling>().enabled = true;
        }
    }


    IEnumerator TimeCount()
    {
        //yield return new WaitForSeconds(0.1f);

        if (UnityEngine.Random.Range(0.0f, 1.0f) <THIEF_CAT_PROB) //20퍼 확률로 도둑고양이
        {
            yield return StartCoroutine("ThiefCatMiniGame");
        }
        ClearPlate();
        StopAndClearSushi();

        //CatObject.SetActive(true);
        CatObject.layer = LayerMask.NameToLayer("CatAppear"); //발 앞쪽으로 레이어 재배치
        CatImageChange(); //고양이 이미지 변경
        CatObject.GetComponent<Animation>().Play("CatUp"); //고양이 올라오기
        CatSoundObj.GetComponent<AudioSource>().Play(); //고양이 등장 소리

        ClearPlate();
        StopAndClearSushi();
        yield return new WaitForSeconds(0.1f);

        SelectMode(); //모드 선택 및 말풍선 보여주기

        yield return new WaitForSeconds(1.95f);
        ClearPlate();
        StopAndClearSushi();
        yield return new WaitForSeconds(0.2f);

        stageCutton.GetComponent<Animation>().Play("CuttonUp"); //커튼 올리기

        CatObject.layer = LayerMask.NameToLayer("CatPlaying"); //초밥 뒤쪽으로 레이어 재배치
        CatObject.GetComponent<DragCat>().enabled = true; //이때부터 다시 고양이가 움직일 수 있도록
        //RedropSushi();
        //ItemFallingObject.GetComponent<ItemFalling>().enabled = true; //다시 아이템 복제 실행

        GameManager.GetComponent<GameScript>().GameIsOver = false;
        GameManager.SetActive(true);
        orderArray[currentModeNum].SetActive(false); //주문 말풍선 감추기

        //DragCat catmove = CatObject.GetComponent<DragCat>();
        //catmove.DishCount = 0; //접시 위치 초기화
        //catmove.firstPlate = 0; //접시 아직 하나도 안 받은 것으로 초기화

        left.value = 1;
        right.value = 1;
        for (int i = 0; i < 30; i++) //30초동안 세기
        {
            yield return new WaitForSeconds(1f);
            left.value -= PER_SECOND;
            right.value -= PER_SECOND;
        }

        stageCutton.GetComponent<Animation>().Play("CuttonDown"); //커튼 내리기

        ClearPlate();
        StopAndClearSushi();

        //CatObject.SetActive(false);
        //ItemFallingObject.GetComponent<ItemFalling>().enabled=false; //아이템 복제 중지하기
        GameManager.SetActive(false);
        CatObject.GetComponent<DragCat>().enabled=false; //고양이 터치로 움직이기 비활성화
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
            ScoreManager.GetComponent<ScoreManager>().ThiefFailed(); //점수 깎기

            TheifCatObject.GetComponent<Image>().sprite= (Sprite)Resources.Load("thiefCatRun", typeof(Sprite));
            TheifCatAnim.Play("ThiefCatRun");
            ThiefCatLaugh.GetComponent<AudioSource>().Play(); //고양이 웃는 소리

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
            ThiefCatCry.GetComponent<AudioSource>().Play(); //유는 고양이 소리
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
        if(DishFalling.fallingSpeed >= 1f)
        {
            DishFalling.fallingSpeed -= 0.5f;
        }
        GuestScore++;
        GuestScoreObject.GetComponent<Text>().text = GuestScore.ToString();
    }

    void CatImageChange() //고양이 이미지 변경
    {
        int temp = UnityEngine.Random.Range(1, CAT_SPRITE_NUM);
        CatImageComponent.sprite = (Sprite)Resources.Load("UserCat/" + temp, typeof(Sprite));
    }
}
