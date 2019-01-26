using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SushiFalling : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }
    float timerFall = 0f;
    public int sushinum;
    public float speed = 0f;
    public bool falling = false;
    

    // Update is called once per frame
    void Update()
    {
        speed = 2550 / DishFalling.fallingSpeed;
        if (!ItemFalling.whichFall&&!falling)
        {
            if (ItemFalling.sushi == sushinum)
            {
                Fall();
                falling = true;
            }
        }
        if (falling)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - speed * Time.deltaTime, 0);
            timerFall += Time.deltaTime;
            if (timerFall > 7f)
                falling = false;
        }
    }

    public void Fall()
    {
        timerFall = 0f;
        transform.localPosition = new Vector3(Random.Range(-520f, 720f), 2550 / 2, 0);
    }
}
