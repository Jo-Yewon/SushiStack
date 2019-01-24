using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SushiFalling : MonoBehaviour
{
    public float timeBetweenFall = 2f;
    // Start is called before the first frame update
    void Start()
    {
        //timeBetweenFall = Random.Range(6f, 15f);
    }

    public float timerFall = 0f;
    public float speed = 0f;
    

    // Update is called once per frame
    void Update()
    {
        timerFall += Time.deltaTime;
        if (timerFall > timeBetweenFall)
        {
            Fall();
        }
        speed = 2550 / DishFalling.fallingSpeed;
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - speed * Time.deltaTime, 0);
    }

    void Fall()
    {
        timerFall = 0f;
        //timeBetweenFall = Random.Range(6f, 15f);
        transform.localPosition = new Vector3(Random.Range(-520f, 720f), 2550 / 2, 0);
    }
}
