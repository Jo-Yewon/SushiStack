using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public GameObject Gamemanager;

    public int itemScore;
    private GameScript GameOver;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject Cat = GameObject.Find("MovingCat");
        DragCat catmove = Cat.GetComponent<DragCat>();

        GameObject Item = this.gameObject;
        DishFalling dishFalling = Item.GetComponent<DishFalling>();

        GameOver = Gamemanager.GetComponent<GameScript>();


        GameObject[] GItem = GameObject.FindGameObjectsWithTag("itemgreen");
        GameObject[] BItem = GameObject.FindGameObjectsWithTag("itemblue");
        GameObject[] RItem = GameObject.FindGameObjectsWithTag("itemred");

        if (catmove.firstPlate == 0 && collision.gameObject.CompareTag("CatCollider"))
        {
            if (Item.CompareTag("itemgreen")) {
                if (catmove.Modenumber != 1 && catmove.Modenumber != 12 && catmove.Modenumber != 13 && catmove.Modenumber != 123)
                            {
                                GameOver.GameIsOver = true;
                            }

                Debug.Log("Tagged");
            }
            else if (Item.CompareTag("itemblue")) {
                if (catmove.Modenumber != 2 && catmove.Modenumber != 12 && catmove.Modenumber != 23 && catmove.Modenumber != 123)
                {
                    GameOver.GameIsOver = true;
                }
            }
            else if (Item.CompareTag("itemred")) {
                if (catmove.Modenumber != 3 && catmove.Modenumber != 13 && catmove.Modenumber != 23 && catmove.Modenumber != 123)
                {
                    GameOver.GameIsOver = true;
                }
            }
            
        }
        else if (catmove.firstPlate == 1 && collision.gameObject.CompareTag("PlateCollider"))
        {
            if (Item.CompareTag("itemgreen"))
            {
                if (catmove.Modenumber != 1 && catmove.Modenumber != 12 && catmove.Modenumber != 13 && catmove.Modenumber != 123)
                {
                    GameOver.GameIsOver = true;
                }
            }
            else if (Item.CompareTag("itemblue"))
            {
                if (catmove.Modenumber != 2 && catmove.Modenumber != 12 && catmove.Modenumber != 23 && catmove.Modenumber != 123)
                {
                    GameOver.GameIsOver = true;
                }
            }
            else if (Item.CompareTag("itemred"))
            {
                if (catmove.Modenumber != 3 && catmove.Modenumber != 13 && catmove.Modenumber != 23 && catmove.Modenumber != 123)
                {
                    GameOver.GameIsOver = true;
                }
            }

            
        }
        Item.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject plate = this.gameObject;

        
    }

}
