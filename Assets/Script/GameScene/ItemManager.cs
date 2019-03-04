using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public GameObject Gamemanager, ScoreManager;
    public static int SushiNum;
    public GameObject turtleLetter, feverLetter, gookLetter;
    public GameObject myFallingManager;

    public int itemScore;
    private GameScript GameOver;
    private DragCat catmove;

    public void Start()
    {
        GameObject Cat = GameObject.Find("MovingCat");
        catmove = Cat.GetComponent<DragCat>();
        SushiNum = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bottom"))
        {
            //Debug.Log("bottom과 충돌");
            gameObject.SetActive(false);
        }

        //GameObject gameObject = this.gameObject;
        //DishFalling dishFalling = Item.GetComponent<DishFalling>();
        //ItemFalling itemFalling = GameObject.Find("2.ItemPanel").GetComponent<ItemFalling>();

        GameOver = Gamemanager.GetComponent<GameScript>();

        /*
        GameObject[] GItem = GameObject.FindGameObjectsWithTag("itemgreen");
        GameObject[] BItem = GameObject.FindGameObjectsWithTag("itemblue");
        GameObject[] RItem = GameObject.FindGameObjectsWithTag("itemred");
        */

        if (catmove.firstPlate == 0 && collision.gameObject.CompareTag("CatCollider"))
        {
            if (gameObject.CompareTag("itemgreen"))   //초록 접시 초밥 방았을때
            {
                //모드체크
                if (catmove.Modenumber != 1 && catmove.Modenumber != 12 && catmove.Modenumber != 13 && catmove.Modenumber != 123)
                {
                    GameOver.GameIsOver = true;
                }
                else
                {
                    //gameObject.GetComponent<SushiFalling>().falling = false;
                    //gameObject.GetComponent<FallingScript>().enabled=false;
                    //gameObject.transform.localPosition = new Vector3(Random.Range(-520f, 520f), 2550 / 2, 0);
                    //Debug.Log("Tagged");
                    gameObject.SetActive(false);
                    ScoreManager.GetComponent<ScoreManager>().ScoreUp(this.itemScore);
                    SushiNum++;
                }
            }
            else if (gameObject.CompareTag("itemblue"))   //파랑 접시 초밥 받았을 때
            {
                if (catmove.Modenumber != 2 && catmove.Modenumber != 12 && catmove.Modenumber != 23 && catmove.Modenumber != 123)
                {
                    GameOver.GameIsOver = true;
                }
                else
                {
                    //gameObject.GetComponent<SushiFalling>().falling = false;
                    //gameObject.GetComponent<FallingScript>().enabled=false;
                    //gameObject.transform.localPosition = new Vector3(Random.Range(-520f, 520f), 2550 / 2, 0);
                    //Debug.Log("Tagged");
                    gameObject.SetActive(false);
                    ScoreManager.GetComponent<ScoreManager>().ScoreUp(this.itemScore);
                    SushiNum++;
                }

            }
            else if (gameObject.CompareTag("itemred"))    //빨강 접시 초밥 받았을 때
            {
                if (catmove.Modenumber != 3 && catmove.Modenumber != 13 && catmove.Modenumber != 23 && catmove.Modenumber != 123)
                {
                    GameOver.GameIsOver = true;
                }
                else
                {
                    //gameObject.GetComponent<SushiFalling>().falling = false;
                    //gameObject.GetComponent<FallingScript>().enabled=false;
                    //gameObject.transform.localPosition = new Vector3(Random.Range(-520f, 520f), 2550 / 2, 0);
                    //Debug.Log("Tagged");
                    gameObject.SetActive(false);
                    ScoreManager.GetComponent<ScoreManager>().ScoreUp(this.itemScore);
                    SushiNum++;
                }
            }
            else if (gameObject.CompareTag("turtle"))     //거북이 받았을떄
            {
                ScoreManager.GetComponent<ScoreManager>().ScoreUp(0);
                //Item.transform.localPosition = new Vector3(Random.Range(-520f, 520f), 2550 / 2, 0);
                //글자 표시
                turtleLetter.GetComponent<Animation>().Play();
                //itemFalling.turtlePower();
                gameObject.SetActive(false);
                myFallingManager.GetComponent<FallingManager>().TurtleStart();
            }
            else if (gameObject.CompareTag("gook"))
            { //국 받았을 때
                ScoreManager.GetComponent<ScoreManager>().ScoreUp(0);
                //Item.transform.localPosition = new Vector3(Random.Range(-520f, 520f), 2550 / 2, 0);
                gookLetter.GetComponent<Animation>().Play();
                //itemFalling.gookPower();
                gameObject.SetActive(false);
                myFallingManager.GetComponent<FallingManager>().GookStart();
            }
            else if (gameObject.CompareTag("RainbowPlate"))
            {
                ScoreManager.GetComponent<ScoreManager>().ScoreUp(0);
                feverLetter.GetComponent<Animation>().Play();
                //gameObject.transform.localPosition = new Vector3(Random.Range(-520f, 520f), 2550 / 2, 0);
                //itemFalling.FeverOn = true;
                // 초밥 점수 2배로 하는 코드 필요
                //this.itemScore *= 2;
                gameObject.SetActive(false);
                myFallingManager.GetComponent<FallingManager>().FeverStart();
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
                if (gameObject.CompareTag("itemgreen"))   //초록 접시 초밥 방았을때
                {
                    //모드체크
                    if (catmove.Modenumber != 1 && catmove.Modenumber != 12 && catmove.Modenumber != 13 && catmove.Modenumber != 123)
                    {
                        GameOver.GameIsOver = true;
                    }
                    else
                    {
                        //gameObject.GetComponent<SushiFalling>().falling = false;
                        //gameObject.GetComponent<FallingScript>().enabled=false;
                        //gameObject.transform.localPosition = new Vector3(Random.Range(-520f, 520f), 2550 / 2, 0);
                        //Debug.Log("Tagged");
                        gameObject.SetActive(false);
                        ScoreManager.GetComponent<ScoreManager>().ScoreUp(this.itemScore);
                        SushiNum++;
                    }
                }
                else if (gameObject.CompareTag("itemblue"))   //파랑 접시 초밥 받았을 때
                {
                    if (catmove.Modenumber != 2 && catmove.Modenumber != 12 && catmove.Modenumber != 23 && catmove.Modenumber != 123)
                    {
                        GameOver.GameIsOver = true;
                    }
                    else
                    {
                        //gameObject.GetComponent<SushiFalling>().falling = false;
                        //gameObject.GetComponent<FallingScript>().enabled=false;
                        //gameObject.transform.localPosition = new Vector3(Random.Range(-520f, 520f), 2550 / 2, 0);
                        //Debug.Log("Tagged");
                        gameObject.SetActive(false);
                        ScoreManager.GetComponent<ScoreManager>().ScoreUp(this.itemScore);
                        SushiNum++;
                    }

                }
                else if (gameObject.CompareTag("itemred"))    //빨강 접시 초밥 받았을 때
                {
                    if (catmove.Modenumber != 3 && catmove.Modenumber != 13 && catmove.Modenumber != 23 && catmove.Modenumber != 123)
                    {
                        GameOver.GameIsOver = true;
                    }
                    else
                    {
                        //gameObject.GetComponent<SushiFalling>().falling = false;
                        //gameObject.GetComponent<FallingScript>().enabled=false;
                        //gameObject.transform.localPosition = new Vector3(Random.Range(-520f, 520f), 2550 / 2, 0);
                        //Debug.Log("Tagged");
                        gameObject.SetActive(false);
                        ScoreManager.GetComponent<ScoreManager>().ScoreUp(this.itemScore);
                        SushiNum++;
                    }
                }
                else if (gameObject.CompareTag("turtle"))     //거북이 받았을떄
                {
                    ScoreManager.GetComponent<ScoreManager>().ScoreUp(0);
                    //Item.transform.localPosition = new Vector3(Random.Range(-520f, 520f), 2550 / 2, 0);

                    turtleLetter.GetComponent<Animation>().Play();
                    //itemFalling.turtlePower();
                    gameObject.SetActive(false);
                    myFallingManager.GetComponent<FallingManager>().TurtleStart();
                }
                else if (gameObject.CompareTag("gook"))
                { //국 받았을 때
                    ScoreManager.GetComponent<ScoreManager>().ScoreUp(0);
                    //Item.transform.localPosition = new Vector3(Random.Range(-520f, 520f), 2550 / 2, 0);
                    gookLetter.GetComponent<Animation>().Play();
                    //itemFalling.gookPower();
                    gameObject.SetActive(false);
                    myFallingManager.GetComponent<FallingManager>().GookStart();
                }
                else if (gameObject.CompareTag("RainbowPlate"))
                {
                    ScoreManager.GetComponent<ScoreManager>().ScoreUp(0);
                    feverLetter.GetComponent<Animation>().Play();
                    //gameObject.transform.localPosition = new Vector3(Random.Range(-520f, 520f), 2550 / 2, 0);
                    //itemFalling.FeverOn = true;
                    // 초밥 점수 2배로 하는 코드 필요
                    //this.itemScore *= 2;
                    gameObject.SetActive(false);
                    myFallingManager.GetComponent<FallingManager>().FeverStart();
                }
            }
            //점수에 아이템 점수 더함
            GameOver.Score += itemScore;
        }


    }

    //bool turnF = false;

    // Update is called once per frame


        /*
    void Update()
    {
        GameObject plate = this.gameObject;
        ItemFalling itemFalling = GameObject.Find("2.ItemPanel").GetComponent<ItemFalling>();

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
    */

}
