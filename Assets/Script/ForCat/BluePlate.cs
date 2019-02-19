using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BluePlate : MonoBehaviour
{
    public GameObject Gamemanager;
    public static int bluePlateNum;
    public Rigidbody2D rb;
    public float YPosition;
    public GameObject Cat;

    private GameObject platecollider;
    private DragCat catmove;
    private int count = 0;
    private GameScript GameOver;

    public void Awake()
    {
        platecollider = gameObject.transform.GetChild(0).gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        catmove = Cat.GetComponent<DragCat>();
        DishFalling dishFalling = gameObject.GetComponent<DishFalling>();

        GameOver = Gamemanager.GetComponent<GameScript>();

        if (catmove.firstPlate == 0 && collision.gameObject.CompareTag("CatCollider"))
        {

            if (catmove.Modenumber != 2 && catmove.Modenumber != 12 && catmove.Modenumber != 23 && catmove.Modenumber != 123)
            {
                GameOver.GameIsOver = true;
            }

            rb.isKinematic = true;
            rb.velocity = new Vector2(0, 0);

            dishFalling.speed = 0;
            catmove.FirstYPosition = transform.position.y;
            YPosition = transform.position.y;
            catmove.firstPlate = 1;
            count++;
            catmove.DishCount++;
        }
        else if (catmove.firstPlate == 1 && collision.gameObject.CompareTag("PlateCollider"))
        {
            if (catmove.Modenumber != 2 && catmove.Modenumber != 12 && catmove.Modenumber != 23 && catmove.Modenumber != 123)
            {
                GameOver.GameIsOver = true;
            }

            rb.isKinematic = true;
            rb.velocity = new Vector2(0, 0);

            dishFalling.speed = 0;

            if (count == 0)
            {
                YPosition = catmove.FirstYPosition + (catmove.DishCount * (0.2f));
            }
            //YPosition = transform.position.y;
            count++;
            //catmove.DishCount++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 2)
        {
            platecollider.SetActive(false);
            catmove.DishCount++;
            bluePlateNum++;
            count++;
            this.enabled = false;
        }
    }
}
