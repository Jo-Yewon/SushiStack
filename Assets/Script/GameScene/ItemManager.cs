using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public GameObject Gamemanager, ScoreManager;

    public int itemScore;
    private GameScript GameOver;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject Cat = GameObject.Find("MovingCat");
        DragCat catmove = Cat.GetComponent<DragCat>();

        GameObject Item = this.gameObject;
        DishFalling dishFalling = Item.GetComponent<DishFalling>();
        ItemFalling itemFalling = GameObject.Find("2.ItemPanel").GetComponent<ItemFalling>();

        GameOver = Gamemanager.GetComponent<GameScript>();

        /*
        GameObject[] GItem = GameObject.FindGameObjectsWithTag("itemgreen");
        GameObject[] BItem = GameObject.FindGameObjectsWithTag("itemblue");
        GameObject[] RItem = GameObject.FindGameObjectsWithTag("itemred");
        */


        if (catmove.firstPlate == 0 && collision.gameObject.CompareTag("CatCollider"))
        {
            if (Item.CompareTag("itemgreen"))   //초록 접시 초밥 방았을때
            {
                //모드체크
                if (catmove.Modenumber != 1 && catmove.Modenumber != 12 && catmove.Modenumber != 13 && catmove.Modenumber != 123)
                {
                    GameOver.GameIsOver = true;
                }
                else
                {
                    Debug.Log("Tagged");
                    ScoreManager.GetComponent<ScoreManager>().ScoreUp(this.itemScore);
                }
            }
            else if (Item.CompareTag("itemblue"))   //파랑 접시 초밥 받았을 때
            {
                if (catmove.Modenumber != 2 && catmove.Modenumber != 12 && catmove.Modenumber != 23 && catmove.Modenumber != 123)
                {
                    GameOver.GameIsOver = true;
                }
                else
                {
                    Debug.Log("Tagged");
                    ScoreManager.GetComponent<ScoreManager>().ScoreUp(this.itemScore);
                }

            }
            else if (Item.CompareTag("itemred"))    //빨강 접시 초밥 받았을 때
            {
                if (catmove.Modenumber != 3 && catmove.Modenumber != 13 && catmove.Modenumber != 23 && catmove.Modenumber != 123)
                {
                    GameOver.GameIsOver = true;
                }
                else
                {
                    Debug.Log("Tagged");
                    ScoreManager.GetComponent<ScoreManager>().ScoreUp(this.itemScore);
                }
            }
            else if (Item.CompareTag("turtle"))     //거북이 받았을떄
            {
                itemFalling.turtlePower();
            }
            else if (Item.CompareTag("gook")) { //국 받았을 때
                itemFalling.gookPower();
            }
            else if (Item.CompareTag("RainbowPlate"))
            {
                DragCat.DishScore *= 2; // 피버타임때 점수가 2배 되므로 접시를 받을때마다 2갰기 받은 것으로 처리
                // 초밥 점수 2배로 하는 코드 필요

            }

            //점수에 아이템 점수 더함
            Item.SetActive(false);
        }
        else if (catmove.firstPlate == 1 && collision.gameObject.CompareTag("PlateCollider"))
        {
            if (Item.CompareTag("itemgreen"))
            {
                if (catmove.Modenumber != 1 && catmove.Modenumber != 12 && catmove.Modenumber != 13 && catmove.Modenumber != 123)
                {
                    GameOver.GameIsOver = true;
                }
                else
                {
                    Debug.Log("Tagged");
                    ScoreManager.GetComponent<ScoreManager>().ScoreUp(this.itemScore);
                }
            }
            else if (Item.CompareTag("itemblue"))
            {
                if (catmove.Modenumber != 2 && catmove.Modenumber != 12 && catmove.Modenumber != 23 && catmove.Modenumber != 123)
                {
                    GameOver.GameIsOver = true;
                }
                else
                {
                    Debug.Log("Tagged");
                    ScoreManager.GetComponent<ScoreManager>().ScoreUp(this.itemScore);
                }
            }
            else if (Item.CompareTag("itemred"))
            {
                if (catmove.Modenumber != 3 && catmove.Modenumber != 13 && catmove.Modenumber != 23 && catmove.Modenumber != 123)
                {
                    GameOver.GameIsOver = true;
                }
                else
                {
                    Debug.Log("Tagged");
                    ScoreManager.GetComponent<ScoreManager>().ScoreUp(this.itemScore);
                }
            }
            else if (Item.CompareTag("turtle"))     //거북이 받았을떄
            {
                itemFalling.turtlePower();
            }
            else if (Item.CompareTag("gook"))
            { //국 받았을 때
                itemFalling.gookPower();
            }
            else if (Item.CompareTag("RainbowPlate"))
            {
                itemFalling.FeverOn = true;
                itemFalling.GetComponent<AudioSource>().Play();
                DragCat.DishScore *= 2; // 피버타임때 점수가 2배 되므로 접시를 받을때마다 2갰기 받은 것으로 처리
                // 초밥 점수 2배로 하는 코드 필요

            }

            //점수에 아이템 점수 더함
        //transform.localPosition = new Vector3(Random.Range(-520f, 520f), 2550 / 2, 0);
            Item.transform.localPosition = new Vector3(Random.Range(-520f, 520f), 2550 / 2, 0);


        }

        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject plate = this.gameObject;

        
    }

}
