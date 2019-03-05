using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingManager : MonoBehaviour
{
    public static float FALLING_SPEED;// 모든 아이템 및 초밥이 떨어지는 속도
    public static float SPEED;
    public readonly static float FALLING_SPEED_MAX = 1f; //아무리 빨리 떨어져도 이 이상은 안갈 범위
    public readonly static float FALLING_SPEED_DOWN_PER_GUEST = 0.5f; //손님 한명 지날때마다 속도 빨라지는 수치
    public static float FALLING_INTERVAL = 1f; //떨어지는 시간 간격
    public static bool IsFall; //외부에서 false로 만들면 새로운 접시, 아이템, 초밥이 떨어지지 않음.
    //public readonly static float ItemDropProb = 0.08f; //매 간격마다 장국이나 거북이가 떨어질 확률.
    public static bool isFeverDrop;

    public GameObject []DishArray = new GameObject[3];
    public GameObject []SushiArray = new GameObject[9];
    public GameObject Turtle, Gook, RainbowDish;
    public GameObject tempItemArray;
    public GameObject scoreManager, feverBG;

    //장국,거북이 떨어지는 간격 범위
    private readonly static float
        ITEM_INTERVAL_MIN = 15f, ITEM_INTERVAL_MAX = 25f;
    private static readonly int[] SushiRangeForAchievementIndex = {3,4,5,5,6,7,7,8,9,9};
    private int sushiRange;
    private bool isItempDrop;
    private bool GookOn;

    void OnEnable()
    {
        FALLING_SPEED = 3f;
        SPEED = 2140 / 3f;

        isFeverDrop = false; isItempDrop = false; GookOn=false;
        IsFall = false; //처음엔 안 떨어지는 상태로 시작
        sushiRange = SushiRangeForAchievementIndex[PlayerDataLoad.playerdata.AchievementIndex];
        StartCoroutine("ItemTimerCoroutine");
        StartCoroutine("Falling");
    }

    IEnumerator ItemTimerCoroutine()
    {
        yield return new WaitForSeconds(Random.Range(ITEM_INTERVAL_MIN, ITEM_INTERVAL_MAX));
        isItempDrop = true;
        StartCoroutine("ItemTimerCoroutine"); //계속 반복
    }


    void DishDrop() //접시 세개 중에 랜덤으로 하나 클론하도록 하는 함수
    {
        //Debug.Log("DishDrop");
        GameObject dishInstance = 
            Instantiate(DishArray[Random.Range(0, 3)], transform.position, transform.rotation) as GameObject;
        dishInstance.transform.SetParent(tempItemArray.transform, false);
        dishInstance.SetActive(true);
    }

    void SushiDrop() //스시 랜덤으로 떨어지도록 하는 함수
    {
        //Debug.Log("SushiDrop");
        int temp = Random.Range(0, sushiRange);
        if (!SushiArray[temp].activeSelf) SushiArray[temp].SetActive(true);
        else
        { //떨어뜨리고 싶은 스시가 떨어지고 있다면 클론하기
            //Debug.Log("스시 클론");
            GameObject sushiInstance =
            Instantiate(SushiArray[temp], SushiArray[temp].transform.position, SushiArray[temp].transform.rotation) as GameObject;
            sushiInstance.transform.SetParent(tempItemArray.transform, false);
        }
    }

    void TurtleDrop()
    {
        //Debug.Log("TDrop");
        if (Turtle.activeSelf) SushiDrop(); //이미 거북이 떨어지는 중이라면 Sushi라도 떨어뜨려라..
        else Turtle.SetActive(true);
    }

    void GookDrop()
    {
        //Debug.Log("GDrop");
        if (Gook.activeSelf) SushiDrop(); //이미 장국이 떨어지는 중이라면 Sushi라도 떨어뜨려라..
        else Gook.SetActive(true);
    }

    void FeverDrop()
    {
        RainbowDish.SetActive(true);
    }

    public static void UpSpeed() //timer30s 에서 이 함수 호출하면 속도 빨라짐.
    {
        /*
        if (FALLING_SPEED >= FALLING_SPEED_MAX)
        {
            FALLING_SPEED -= FALLING_SPEED_DOWN_PER_GUEST;
            SPEED = 2140 / FALLING_SPEED;
        }
        */
        FALLING_SPEED -= 0.5f/Timer30s.GuestScore; //발이 내려올때마다 FALLING_SPEED가 0.5/n만큼 감소하도록 수정
        SPEED = 2140 / FALLING_SPEED;
    }



    IEnumerator Falling()
    {
        yield return new WaitForSeconds(FALLING_INTERVAL);
        if (IsFall) //isFall이 true일 때만 떨어뜨리기
        {
            if (isFeverDrop)
            {
                FeverDrop();
                isFeverDrop = false;
            }
            else if (isItempDrop)
            {
                if (Random.Range(0f, 1f) < 0.5f) TurtleDrop();
                else GookDrop();
                isItempDrop = false;
            }
            else
            {
                if (GookOn) SushiDrop(); //장국 효과 적용중에는 스시만...
                else
                {
                    if (Random.Range(0f, 1f) < 0.5f) DishDrop();
                    else SushiDrop();
                }
            }
        }
        StartCoroutine("Falling"); //떨어지는건 계속 반복
    }

    public void FeverStart() //무지개접시 받았을 때 외부에서 호출됨
    {
        StartCoroutine("FeverCoroutine");
    }

    IEnumerator FeverCoroutine()
    {
        scoreManager.GetComponent<ScoreManager>().isFeverOn = true; //점수 두배로 계산하도록
        feverBG.SetActive(true);
        GameObject.FindGameObjectWithTag("SoundManager").GetComponent<BGMScript>().PauseGameBGM();
        this.GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(10f);//피버는 10초

        scoreManager.GetComponent<ScoreManager>().isFeverOn = false; //점수 두배로 계산하도록
        feverBG.SetActive(false);
        this.GetComponent<AudioSource>().Stop();
        GameObject.FindGameObjectWithTag("SoundManager").GetComponent<BGMScript>().GameBGMPlay();
    }

    public void GookStart()
    {
        StartCoroutine("GookCoroutine");
    }

    IEnumerator GookCoroutine()
    {
        int temp;
        GameObject temp_gameObj;

        GookOn = true; //장국효과 키기.. 접시가 새로 생성안되고 전부 스시만 나옴
        for (int i = 0; i < tempItemArray.transform.childCount; i++)
        {
            temp_gameObj = tempItemArray.transform.GetChild(i).gameObject;
            temp =-1;
            if (temp_gameObj.CompareTag("GreenPlate")&& !temp_gameObj.GetComponent<Rigidbody2D>().isKinematic)
            {
                if (sushiRange <= 3) temp = 0;
                else if (sushiRange <= 4)
                {
                    switch (Random.Range(0, 2))
                    {
                        case 0:
                            temp = 0;
                            break;
                        case 1:
                            temp = 3;
                            break;
                    }
                }
                else
                {
                    switch (Random.Range(0, 3))
                    {
                        case 0:
                            temp = 0;
                            break;
                        case 1:
                            temp = 3;
                            break;
                        case 3:
                            temp = 4;
                            break;
                    }
                }
            }
            else if (temp_gameObj.CompareTag("BluePlate") && !temp_gameObj.GetComponent<Rigidbody2D>().isKinematic)
            {
                if (sushiRange <= 5) temp = 1;
                else if (sushiRange <= 6)
                {
                    switch (Random.Range(0, 2))
                    {
                        case 0:
                            temp = 1;
                            break;
                        case 1:
                            temp = 5;
                            break;
                    }
                }
                else
                {
                    switch (Random.Range(0, 3))
                    {
                        case 0:
                            temp = 1;
                            break;
                        case 1:
                            temp = 5;
                            break;
                        case 3:
                            temp = 6;
                            break;
                    }
                }
            }
            else if (temp_gameObj.CompareTag("RedPlate") && !temp_gameObj.GetComponent<Rigidbody2D>().isKinematic)
            {
                if (sushiRange <= 7) temp = 2;
                else if (sushiRange <= 8)
                {
                    switch (Random.Range(0, 2))
                    {
                        case 0:
                            temp = 2;
                            break;
                        case 1:
                            temp = 7;
                            break;
                    }
                }
                else
                {
                    switch (Random.Range(0, 3))
                    {
                        case 0:
                            temp = 2;
                            break;
                        case 1:
                            temp = 7;
                            break;
                        case 3:
                            temp = 8;
                            break;
                    }
                }
            }
            if (temp == -1) continue;
            if (!SushiArray[temp].activeSelf)
            {
                SushiArray[temp].SetActive(true);
                SushiArray[temp].GetComponent<RectTransform>().localPosition = temp_gameObj.GetComponent<RectTransform>().localPosition;
                temp_gameObj.SetActive(false);
            }
            else
            {
                GameObject sushiInstance =
           Instantiate(SushiArray[temp], SushiArray[temp].transform.position, SushiArray[temp].transform.rotation) as GameObject;
                sushiInstance.transform.SetParent(tempItemArray.transform, false);
                sushiInstance.GetComponent<RectTransform>().localPosition = temp_gameObj.GetComponent<RectTransform>().localPosition;
                temp_gameObj.SetActive(false);
            }
        }
        yield return new WaitForSeconds(9.8f);

        GookOn = false; // 장국효과 Off
    }

    public void TurtleStart() //거북이 받았을 때 외부에서 호출됨.
    {
        StartCoroutine("TurtleCoroutine");
    }

    IEnumerator TurtleCoroutine()
    {
        float originalSpeed1 = FALLING_SPEED, originalSpeed2 = SPEED; //현재 스피드 저장

        //FALLING_SPEED += 1f;
        FALLING_SPEED += 0.5f;
        SPEED = 2140 / FALLING_SPEED;

        yield return new WaitForSeconds(10f); //10초동안 효과 지속

        FALLING_SPEED = originalSpeed1;
        SPEED = originalSpeed2;
    }
}
