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
    public float whichItem = 0f;
    public float temp = 0f;
    float effectTime = 0f;
    
    public GameObject turtle;
    public GameObject gook;
    

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
            else if(whichItem > 0)//양수면 장국
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
                turtle.transform.localPosition = new Vector3(Random.Range(-520f, 520f), 2550 / 2+182, 0);
            }
            else
            {
                turtle.transform.position = new Vector3(turtle.transform.position.x, turtle.transform.position.y - (500 * Time.deltaTime), 0);
            }
        }else if(whichItem > 0)
        {
            if(effectTime > 3f)
            {
                whichItem = 0;
            }
            gook.transform.position = new Vector3(gook.transform.position.x, gook.transform.position.y - (500 * Time.deltaTime), 0);

        }

    }

    public Transform parent;
    public float fallingSpeed = 7f;

    void turtlePower()
    {
        turtle.transform.localPosition = new Vector3(Random.Range(-520f, 720f), 2550 / 2+182, 0);
        DishFalling.fallingSpeed += 2;
    }

    void gookPower()
    {
                gook.transform.localPosition = new Vector3(Random.Range(-520f, 520f), 2550 / 2+182, 0);

    }


}
