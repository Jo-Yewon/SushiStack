using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToRainbowDish : MonoBehaviour
{
    public GameObject FeverItemManagerObj;

    void Start()
    {
        //화면 상단, x는 랜덤으로 이동하기
        gameObject.transform.localPosition =
            new Vector3(Random.Range(-520f, 520f), 2550 / 2, 0);
    }

    void Update()
    {
        //떨어지기
        transform.localPosition =
                new Vector3(transform.localPosition.x,
                transform.localPosition.y - 713 * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bottom")) //바닥에 닿으면 다시 위로.. 하나 받을때까지 계속
        {
            //Debug.Log("위로");
            gameObject.transform.localPosition =
            new Vector3(Random.Range(-520f, 520f), 2550 / 2, 0);
        }
        else if (collision.gameObject.CompareTag("CatCollider")) //고양이랑 충돌시
        {
            //Debug.Log("고양이랑 충돌");
            FeverItemManagerObj.GetComponent<FeverItemManager>().RainbowDishGet();
            gameObject.SetActive(false);
        }
    }
}
