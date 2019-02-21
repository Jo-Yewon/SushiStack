using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public GameObject Gamemanager, ScoreManager;
    public static int SushiNum;

    public int itemScore;
    private GameScript GameOver;
    private DragCat catmove;

    public void Start()
    {
        GameObject Cat = GameObject.Find("MovingCat");
        catmove = Cat.GetComponent<DragCat>();

        SushiNum = 0;
    }

    public void OnEnable()
    {
        if(gameObject.CompareTag("turtle"))
            gameObject.transform.localPosition = new Vector3(Random.Range(-520f, 520f), 2550 / 2, 0); //화면 상단으로
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
        GameObject Cat = GameObject.Find("MovingCat");
        DragCat catmove = Cat.GetComponent<DragCat>();
        */

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
                    Item.GetComponent<SushiFalling>().falling = false;
                    Item.transform.localPosition = new Vector3(Random.Range(-520f, 520f), 2550 / 2, 0);
                    Debug.Log("Tagged");
                    ScoreManager.GetComponent<ScoreManager>().ScoreUp(this.itemScore);
                    SushiNum++;
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
                    Item.GetComponent<SushiFalling>().falling = false;
                    Item.transform.localPosition = new Vector3(Random.Range(-520f, 520f), 2550 / 2, 0);
                    Debug.Log("Tagged");
                    ScoreManager.GetComponent<ScoreManager>().ScoreUp(this.itemScore);
                    SushiNum++;
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
                    Item.GetComponent<SushiFalling>().falling = false;
                    Item.transform.localPosition = new Vector3(Random.Range(-520f, 520f), 2550 / 2, 0);
                    Debug.Log("Tagged");
                    ScoreManager.GetComponent<ScoreManager>().ScoreUp(this.itemScore);
                    SushiNum++;
                }
            }
            else if (Item.CompareTag("turtle"))     //거북이 받았을떄
            {
                ScoreManager.GetComponent<ScoreManager>().ScoreUp(0);
                //Item.transform.localPosition = new Vector3(Random.Range(-520f, 520f), 2550 / 2, 0);
                itemFalling.turtlePower();
                gameObject.SetActive(false);
            }
            else if (Item.CompareTag("gook"))
            { //국 받았을 때
                ScoreManager.GetComponent<ScoreManager>().ScoreUp(0);
                Item.transform.localPosition = new Vector3(Random.Range(-520f, 520f), 2550 / 2, 0);
                itemFalling.gookPower();
            }
            else if (Item.CompareTag("RainbowPlate"))
            {
                Debug.Log("Rainbow");
                ScoreManager.GetComponent<ScoreManager>().ScoreUp(0);
                Item.transform.localPosition = new Vector3(Random.Range(-520f, 520f), 2550 / 2, 0);
                itemFalling.FeverOn = true;
                // 초밥 점수 2배로 하는 코드 필요
                //this.itemScore *= 2;

            }
            //점수에 아이템 점수 더함
            GameOver.Score += itemScore;

        }
        else if (catmove.firstPlate == 1 && collision.gameObject.CompareTag("PlateCollider"))
        {
            GameObject ob = collision.gameObject.transform.parent.gameObject;
            DishFalling dF = ob.GetComponent<DishFalling>();

            int count = 0;

            if (dF.dishNum == 1) { count = ob.GetComponent<GreenPlate>().Count; }
            else if (dF.dishNum == 2) { count = ob.GetComponent<BluePlate>().Count; }
            else if (dF.dishNum == 3) { count = ob.GetComponent<RedPlate>().Count; }

            if (count == 1)
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
                        Item.GetComponent<SushiFalling>().falling = false;
                        Item.transform.localPosition = new Vector3(Random.Range(-520f, 520f), 2550 / 2, 0);
                        Debug.Log("Tagged");
                        ScoreManager.GetComponent<ScoreManager>().ScoreUp(this.itemScore);
                        SushiNum++;
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
                        Item.GetComponent<SushiFalling>().falling = false;
                        Item.transform.localPosition = new Vector3(Random.Range(-520f, 520f), 2550 / 2, 0);
                        Debug.Log("Tagged");
                        ScoreManager.GetComponent<ScoreManager>().ScoreUp(this.itemScore);
                        SushiNum++;
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
                        Item.GetComponent<SushiFalling>().falling = false;
                        Item.transform.localPosition = new Vector3(Random.Range(-520f, 520f), 2550 / 2, 0);
                        Debug.Log("Tagged");
                        ScoreManager.GetComponent<ScoreManager>().ScoreUp(this.itemScore);
                        SushiNum++;
                    }
                }
                else if (Item.CompareTag("turtle"))     //거북이 받았을떄
                {
                    ScoreManager.GetComponent<ScoreManager>().ScoreUp(0);
                    //Item.transform.localPosition = new Vector3(Random.Range(-520f, 520f), 2550 / 2, 0);
                    itemFalling.turtlePower();
                    gameObject.SetActive(false);
                }
                else if (Item.CompareTag("gook"))
                { //국 받았을 때
                    ScoreManager.GetComponent<ScoreManager>().ScoreUp(0);

                    Item.transform.localPosition = new Vector3(Random.Range(-520f, 520f), 2550 / 2, 0);
                    itemFalling.gookPower();
                }
                else if (Item.CompareTag("RainbowPlate"))
                {
                    ScoreManager.GetComponent<ScoreManager>().ScoreUp(0);
                    Debug.Log("Rainbow");
                    Item.transform.localPosition = new Vector3(Random.Range(-520f, 520f), 2550 / 2, 0);
                    itemFalling.FeverOn = true;
                    // 초밥 점수 2배로 하는 코드 필요
                    //this.itemScore *= 2;
                }
            }
            //점수에 아이템 점수 더함
            GameOver.Score += itemScore;
        }


    }

    bool turnF = false;

    // Update is called once per frame

    void Update()
    {
        GameObject plate = this.gameObject;
        ItemFalling itemFalling = GameObject.Find("2.ItemPanel").GetComponent<ItemFalling>();

        if (gameObject.CompareTag("turtle"))
            transform.localPosition = 
                new Vector3(transform.localPosition.x, transform.localPosition.y - (2140 / DishFalling.fallingSpeed * Time.deltaTime), 0); //떨어지기

        if (itemFalling.FeverOn)
        {
            if (!turnF)
            {
                this.itemScore *= 2;
                Debug.Log(this.gameObject.name + this.itemScore);
            }
            turnF = true;

        }
        else
        {
            if (turnF)
            {
                Debug.Log(this.gameObject.name + this.itemScore);
                itemScore /= 2;
            }
            turnF = false;
        }

    }

}
