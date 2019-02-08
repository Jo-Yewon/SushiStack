using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    public GameObject LuckyCatItemPanel;
    public GameObject OrderPanel;
    public int Score;
    public bool GameIsOver = false;

    private GameObject O1, O2, O3, O12, O13, O23, O123;
    private GameObject Cat;
    private DragCat catmove;
    private Transform OrderPanelTransForm;

    void Awake()
    {
        Cat = GameObject.Find("MovingCat");
        catmove = Cat.GetComponent<DragCat>();
        OrderPanelTransForm = OrderPanel.transform;

        O1 = OrderPanel.transform.GetChild(0).gameObject;
        O2 = OrderPanel.transform.GetChild(1).gameObject;
        O3 = OrderPanel.transform.GetChild(2).gameObject;
        O12 = OrderPanel.transform.GetChild(3).gameObject;
        O13 = OrderPanel.transform.GetChild(4).gameObject;
        O23 = OrderPanel.transform.GetChild(5).gameObject;
        O123 = OrderPanel.transform.GetChild(6).gameObject;

        Score = 0;
        GameIsOver = false;
    }

    // Start is called before the first frame update
    void OnEnable()
    {
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

        Debug.Log("catMove의 ModeNumber는 " + catmove.Modenumber);
    }

    // Update is called once per frame
    void Update()
    {
        Score = catmove.DishCount * 10;

        if (GameIsOver == true) {
            LuckyCatItemPanel.SetActive(true);
        }
    }
}
