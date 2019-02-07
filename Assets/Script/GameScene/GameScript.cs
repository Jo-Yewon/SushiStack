using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    public GameObject LuckyCatItemPanel;
    public int Score;

    public bool GameIsOver = false;

    // Start is called before the first frame update
    void OnEnable()
    {
        GameObject Cat = GameObject.Find("MovingCat");
        DragCat catmove = Cat.GetComponent<DragCat>();

        GameObject O1 = GameObject.Find("Order1");
        GameObject O2 = GameObject.Find("Order2");
        GameObject O3 = GameObject.Find("Order3");
        GameObject O12 = GameObject.Find("Order12");
        GameObject O13 = GameObject.Find("Order13");
        GameObject O23 = GameObject.Find("Order23");
        GameObject O123 = GameObject.Find("Order123");

        if (O1.activeSelf == true)
            catmove.Modenumber = 1;
        if (O2.activeSelf == true)
            catmove.Modenumber = 2;
        if (O3.activeSelf == true)
            catmove.Modenumber = 3;
        if (O12.activeSelf == true)
            catmove.Modenumber = 12;
        if (O13.activeSelf == true)
            catmove.Modenumber = 13;
        if (O23.activeSelf == true)
            catmove.Modenumber = 23;
        if (O123.activeSelf == true)
            catmove.Modenumber = 123;


        Score = 0;

        GameIsOver = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject Cat = GameObject.Find("MovingCat");
        DragCat catmove = Cat.GetComponent<DragCat>();

        Score = catmove.DishCount * 10;

        if (GameIsOver == true) {
            LuckyCatItemPanel.SetActive(true);
        }

    }
}
