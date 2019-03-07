using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleItemManager : MonoBehaviour
{
    public GameObject[] DishAndSushi = new GameObject[4];
    public GameObject TurtleObj, TurtleEffect;
    public GameObject TurtleMObj, stageCutton;
    public GameObject TempItem, CatObj;

    private int getNum;


    // Start is called before the first frame update
    void Start()
    {
        getNum = 0;
        TurtleObj.SetActive(true);
        CatObj.GetComponent<TDragCat>().CatInit();
    }

    public void TurtleGet()
    {
        CatObj.GetComponent<TDragCat>().CatInit();
        TurtleEffect.GetComponent<Animation>().Play();
        //이제부터 접시랑 초밥 떨어뜨리기
        StartCoroutine("DishAndSushiDrop");

    }

    void Drop()
    {
        GameObject Instance =
            Instantiate(DishAndSushi[Random.Range(0,4)], TempItem.transform) as GameObject;
        //Instance.transform.SetParent(TempItem.transform);
        Instance.SetActive(true);
    }

    IEnumerator DishAndSushiDrop()
    {
        while (true)
        {
                yield return new WaitForSeconds(1f);
                Drop(); //1초 간격으로 떨어뜨리기
        }
    }

    public void GetDishOrSushi()
    {
        getNum++;
        if (getNum >= 3)
        {
            TurtleMObj.GetComponent<TurtleTutorialManager>().End();
            stageCutton.GetComponent<Animation>().Play("CuttonDown"); //커튼 올리기
            gameObject.SetActive(false);
        }
    }
}
