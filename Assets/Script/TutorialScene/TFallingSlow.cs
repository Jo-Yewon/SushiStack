using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TFallingSlow : MonoBehaviour
{
    private readonly static float SPEED = 535f;

    public void OnEnable()
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
                transform.localPosition.y - SPEED * Time.deltaTime, 0);
    }
}
