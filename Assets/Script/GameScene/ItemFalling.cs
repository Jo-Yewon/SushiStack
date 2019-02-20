using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFalling : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeBetweenFall = 2f;

    void Start()
    {
        timeBetweenFall = Random.Range(10f, 15f);
    }

    float itemTimer = 0f;
    float feverTimer = 0f;
    public float whichItem = 0f;
    public float temp = 0f;
    float effectTime = 0f;
    
    public GameObject turtle;
    public GameObject gook;
    public GameObject rainbowDish;
    public GameObject feverBG;

    // 접시 떨어지는 코드 관련 변수
    float timerFall = 0f;
    float dishTimeBetweenFall = 2f;
    public float speed = 0f;
    public float choose; // 접시와 초밥 중 어떤 것을 떨어뜨릴 지 결정하는 변수

    private bool feverOn = false;
    public bool turtleOn = false;
    public static bool gookOn = false;
    public static bool whichFall = true;
    public static float sushi;
    public static int dish;
    public int tmp;

    // Update is called once per frame
    void Update()
    {
        itemTimer += Time.deltaTime;
        if (itemTimer > timeBetweenFall && whichItem==0 )
        {
            while (whichItem == 0f)
                whichItem = Random.Range(-3f, 0f);  //랜덤으로 음수 양수를 정해서 아이템 선택 거북이만 나옴

            itemTimer = 0f;
            effectTime = 0f;    // 
            timeBetweenFall = Random.Range(10f, 15f);
        }
        if(whichItem < 0)
        {
            turtle.transform.localPosition = new Vector3(turtle.transform.localPosition.x, turtle.transform.localPosition.y - (2140/DishFalling.fallingSpeed * Time.deltaTime), 0);
            
        }
        if (whichItem > 0)
        {
            gook.transform.localPosition = new Vector3(gook.transform.localPosition.x, gook.transform.localPosition.y - (2140/DishFalling.fallingSpeed * Time.deltaTime), 0);
        }

        if (gookOn)
        {
            effectTime += Time.deltaTime;
            if (effectTime > 3f)
            {
                whichItem = 0;
                gookOn = false;
                effectTime = 0f;
            }
        }

        if (turtleOn)
        {
            effectTime += Time.deltaTime;
            if (effectTime > 10f)
            {
                DishFalling.fallingSpeed -= 2;
                whichItem = 0;//아무 아이템도 내려오고 있지 않은 상태를 만들기 위해.
            }
        }

        //무지개 초밥(피버타임)
        if (Timer30s.GuestScore % 3 == 0)   // 고양이가 3의 배수 번째 고양이 일때
        {
            feverTimer += Time.deltaTime;
           
        }
        else
            feverTimer = 0;

        if (feverTimer > 15f)   // 무지개 접시 떨어뜨리기
        {

            if (feverOn)
            {
                Debug.Log("fever on");
                feverTimer = 0;
                feverBG.SetActive(true);
                GameObject.FindGameObjectWithTag("SoundManager").GetComponent<BGMScript>().PauseGameBGM();
                this.GetComponent<AudioSource>().Play();
                rainbowDish.transform.localPosition = new Vector3(0, 1335, 0);
            }
            else
                rainbowDish.transform.localPosition = new Vector3(rainbowDish.transform.localPosition.x, rainbowDish.transform.localPosition.y - (2140 / DishFalling.fallingSpeed * Time.deltaTime), 0);
        }
        else if (feverOn)
        {
            if (feverTimer > 10f)
            {
                feverOn = false;
                feverBG.SetActive(false);
                this.GetComponent<AudioSource>().Stop();
                GameObject.FindGameObjectWithTag("SoundManager").GetComponent<BGMScript>().GameBGMPlay();

                feverTimer = 0;
            }
        }

        // 접시 또는 초밥 떨어뜨리기
        timerFall += Time.deltaTime;    // 시간 재기
        if(timerFall > dishTimeBetweenFall) // 일정한 간격마다 접시 또는 초밥을 떨어뜨림
        {
            timerFall = 0f;
            choose = Random.Range(-1f, 1);   // 접시와 초밥 중 선택
            if (choose < 0)
            {
                whichFall = false;
                sushiRange = PlayerDataLoad.playerdata.AchievementIndex + 2;
                sushi = Random.Range(1f, sushiRange);
            }
            else
            {
                whichFall = true;
                dish = (int)Random.Range(1f, 4f);
                DishFalling.falling = false;
            }
            
        }
    }
    public int sushiRange;
    //public float fallingSpeed = 7f;

    public bool FeverOn { get => feverOn; set => feverOn = value; }

    public void turtlePower()
    {
        turtle.transform.localPosition = new Vector3(Random.Range(-520f, 520f), 2550 / 2+182, 0);
        DishFalling.fallingSpeed += 2;
        turtleOn = true;
    }

    public void gookPower()
    {
        gook.transform.localPosition = new Vector3(Random.Range(-520f, 520f), 2550 / 2+182, 0);
        gookOn = true;
    }


}
