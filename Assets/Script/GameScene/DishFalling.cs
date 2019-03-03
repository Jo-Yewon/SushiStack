using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishFalling : MonoBehaviour
{

    public int dishNum;
    public static float timerFall = 0f;
    public static float fallingSpeed = 3f;
    public float speed = 0f;
    GameObject dish;
    public GameObject sushi;
    public static bool falling = true;
    public bool isGookTurn = false;
    public GameObject tempItemArray;
    int c;

    // Start is called before the first frame update
    void Start()
    {
        fallingSpeed = 3f;
        if (dishNum == 2)
        {
            dish = GameObject.Find("blueDish");
            sushi = GameObject.Find("Blue1"); //임의로
        }
        if (dishNum == 1)
        {
            dish = GameObject.Find("greenDish");
            sushi = GameObject.Find("Low1");
        }
        if (dishNum == 3)
        {
            dish = GameObject.Find("redDish");
            sushi = GameObject.Find("Red1");
        }
        speed = 2140 / fallingSpeed;
        //parent = dish.transform.parent;
    }

    // Update is called once per frame
    GameObject change;

    void Update()
    {

        if (ItemFalling.whichFall && !falling)
        {
            if (dishNum == ItemFalling.dish)    // ItemFalling 스크립트에서 랜덤으로 나온 숫자와 일치하는 접시를 떨어뜨림.
            {
                Fall();
                falling = true;
            }

        }

        if (dishNum == 1)
        {
            c = this.GetComponent<GreenPlate>().Count;
        }
        if (dishNum == 2)
        {
            c = this.GetComponent<BluePlate>().Count;

        }
        if (dishNum == 3)
        {
            c = this.GetComponent<RedPlate>().Count;

        }

        /* 장국은 동아리 최종발표 이후에 재수정
        if (ItemFalling.gookOn)
        {
            //transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - speed * Time.deltaTime, -10);
            if (count == 0 && !this.gameObject.Equals(dish))
            {
                if (!isGookTurn)
                {
                    change = Instantiate(sushi, transform) as GameObject;
                    change.transform.SetParent(tempItemArray.transform, false);
                    transform.localScale = new Vector3(0, 0, 0);
                }
                isGookTurn = true;
                change.transform.localPosition = new Vector3(change.transform.localPosition.x, change.transform.localPosition.y - speed * Time.deltaTime, -10);
            }
        }
        else if(isGookTurn)
        {
            Destroy(change);
            isGookTurn = false;
            this.gameObject.SetActive(false);
            //transform.localScale = new Vector3(1, 1, 1);
           // Destroy(this.gameObject);
        }
        else
        */
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - speed * Time.deltaTime, 0);


        if (transform.localPosition.y < -(2560 / 2))
        {
            if (this.gameObject.Equals(dish))
                speed = 0;
            else
                Destroy(this.gameObject);

        }

    }

    public static Transform parent;

    void Fall()
    {
        timerFall = 0f;
        GameObject dishInstance = Instantiate(dish, transform.position, transform.rotation) as GameObject;

        // dishInstance.transform.SetParent(parent, false);
        dishInstance.transform.SetParent(tempItemArray.transform, false);
        dishInstance.transform.localPosition = new Vector3(Random.Range(-520f, 520f), 2550 / 2, 0);
        dishInstance.GetComponent<DishFalling>().speed= 2140 / fallingSpeed;
    }
}
