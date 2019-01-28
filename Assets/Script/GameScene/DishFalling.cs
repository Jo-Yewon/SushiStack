using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishFalling : MonoBehaviour
{
    

    public static float timerFall = 0f;
    public static float fallingSpeed = 7f;
    public float speed = 0f;
    GameObject dish;
    public static bool falling = true;
    
    // Start is called before the first frame update
    void Start()
    {
        dish = GameObject.Find("greenDish");
        speed = 2140 / fallingSpeed; ;
        parent = dish.transform.parent;
    }
    // Update is called once per frame
    void Update()
    {
        
        if (ItemFalling.whichFall && !falling)
        {
            Fall();
            falling = true;
            
        }
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
        
        dishInstance.transform.SetParent(parent,false);
        dishInstance.transform.localPosition = new Vector3(Random.Range(-520f, 720f), 2550/2, 0);

        //Destroy(dishInstance, fallingSpeed);
    }
}
