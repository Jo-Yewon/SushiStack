using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishFalling : MonoBehaviour
{

    public int dishNum;
    public static float timerFall = 0f;
    public static float fallingSpeed = 7f;
    public float speed = 0f;
    GameObject dish;
    public GameObject sushi;
    public static bool falling = true;
    public bool isGookTurn = false;
    public GameObject tempItemArray;

    // Start is called before the first frame update
    void Start()
    {
        if (dishNum == 1)
        {
            dish = GameObject.Find("blueDish");
            sushi = GameObject.Find("Low2Shrimp"); //임의로
        }
        if (dishNum == 2)
        {
            dish = GameObject.Find("greenDish");
            sushi = GameObject.Find("Low1Egg");
        }
        if (dishNum == 3)
        {
            dish = GameObject.Find("redDish");
            sushi = GameObject.Find("Low3Cucumber");
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

        if (ItemFalling.gookOn)
        {
            if (!isGookTurn)
            {
                change = Instantiate(sushi, transform) as GameObject;
                //change.transform.SetParent(parent, false);
                change.transform.SetParent(tempItemArray.transform, false);
            }
            isGookTurn = true;
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - speed * Time.deltaTime, -10);
            transform.localScale = new Vector3(0, 0, 0);
            change.transform.localPosition = transform.localPosition;
        }
        else if(isGookTurn)
        {
            transform.localScale = new Vector3(1, 1, 1);
            Destroy(change);
            isGookTurn = false;
        }else
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
    }
}
