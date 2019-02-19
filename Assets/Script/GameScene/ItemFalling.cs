﻿using System.Collections;
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
    public float whichItem = 0f;
    public float temp = 0f;
    float effectTime = 0f;
    
    public GameObject turtle;
    public GameObject gook;

    // 접시 떨어지는 코드 관련 변수
    public static float timerFall = 0f;
    float dishTimeBetweenFall = 2f;
    public float speed = 0f;
    public float choose; // 접시와 초밥 중 어떤 것을 떨어뜨릴 지 결정하는 변수
    public static bool gookOn = false;
    public static bool whichFall = true;
    public static int sushi;
    public static int dish;
    public int tmp;
    // Update is called once per frame
    void Update()
    {
        itemTimer += Time.deltaTime;
        effectTime += Time.deltaTime;
        if (itemTimer > timeBetweenFall && whichItem==0 )
        {
            while (whichItem == 0f)
                whichItem = Random.Range(-1f, 1f);  //랜덤으로 음수 양수를 정해서 아이템 선택
            if (whichItem < 0)  //음수면 거북이
                turtlePower();
            if(whichItem > 0)//양수면 장국
                gookPower();

            itemTimer = 0f;
            effectTime = 0f;    // 
            timeBetweenFall = Random.Range(10f, 15f);
        }
        if(whichItem < 0)
        {
            if (effectTime > 10f)
            {
                DishFalling.fallingSpeed -= 2;
                whichItem = 0;//아무 아이템도 내려오고 있지 않은 상태를 만들기 위해.
                //turtle.transform.localPosition = new Vector3(Random.Range(-520f, 520f), 2550 / 2+182, 0);
            }
            
            turtle.transform.localPosition = new Vector3(turtle.transform.localPosition.x, turtle.transform.localPosition.y - (2140/DishFalling.fallingSpeed * Time.deltaTime), 0);
            
        }
        else if(turtle.transform.localPosition.y < (2550 / 2))
            turtle.transform.localPosition = new Vector3(turtle.transform.localPosition.x, turtle.transform.localPosition.y - (2140 / DishFalling.fallingSpeed * Time.deltaTime), 0);

        if (whichItem > 0 )
        {
            if(effectTime > 3f)
            {
                whichItem = 0;
                gookOn = false;
            }
            gook.transform.localPosition = new Vector3(gook.transform.localPosition.x, gook.transform.localPosition.y - (2140/DishFalling.fallingSpeed * Time.deltaTime), 0);

        }else if(gook.transform.localPosition.y<2550/2)
            gook.transform.localPosition = new Vector3(gook.transform.localPosition.x, gook.transform.localPosition.y - (2140/DishFalling.fallingSpeed * Time.deltaTime), 0);


        // 접시 또는 초밥 떨어뜨리기
        timerFall += Time.deltaTime;    // 시간 재기
        if(timerFall > dishTimeBetweenFall) // 일정한 간격마다 접시 또는 초밥을 떨어뜨림
        {
            choose = Random.Range(-1f, 1f);   // 접시와 초밥 중 선택
            if(choose < 0)
            {
                whichFall = false;
                float sushiRange;

                //점수에 따라 나오는 초밥의 종류가 늘어나게 (30,60은 임의의 숫자)
                // ***칭호에 따라 달라지도록 변환하기
                // PlayerDataLoad.playerdata.AchievementInd
                /*  어떻게 하는 지 알고나서 풀게요..
                int score = GameObject.Find("GameManager").GetComponent<GameScript>().getScore();
                if (score < 30)
                    sushiRange = 2f;
                else if (score < 60)
                    sushiRange = 3f;
                else
                */
                    sushiRange = 4f;

                sushi = (int)Random.Range(1f, sushiRange);
                tmp = sushi;
            }
            else
            {
                whichFall = true;
                dish = (int)Random.Range(1f, 4f);
                DishFalling.falling = false;
            }
            timerFall = 0f;
        }
        


    }

    public float fallingSpeed = 7f;

    void turtlePower()
    {
        turtle.transform.localPosition = new Vector3(Random.Range(-520f, 520f), 2550 / 2+182, 0);
        DishFalling.fallingSpeed += 2;
    }

    void gookPower()
    {
        gook.transform.localPosition = new Vector3(Random.Range(-520f, 520f), 2550 / 2+182, 0);
        //gookOn = true;
    }


}
