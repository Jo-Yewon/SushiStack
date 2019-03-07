using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GookItemPanel : MonoBehaviour
{
    public GameObject[] Sushi = new GameObject[2];
    public GameObject TempItem, CatObj;
    public GameObject GookObj, GookEffect;
    public GameObject GookTutorialManagerobj;
    public GameObject StageCutton;

    private int getNum;

    // Start is called before the first frame update
    void Start()
    {
        getNum = 0;
        GookObj.SetActive(true);
        CatObj.GetComponent<TDragCat>().CatInit();
    }

    public void GookGet()
    {
        CatObj.GetComponent<TDragCat>().CatInit();
        GookEffect.GetComponent<Animation>().Play();
        StartCoroutine("SushiDrop"); //스시 드랍 시작
    }

    void Drop()
    {
        GameObject Instance =
            Instantiate(Sushi[Random.Range(0, 2)], TempItem.transform) as GameObject;
        //Instance.transform.SetParent(TempItem.transform);
        Instance.SetActive(true);
    }

    IEnumerator SushiDrop()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            Drop(); //1초 간격으로 떨어뜨리기
        }
    }

    public void GetSushi()
    {
        getNum++;
        if (getNum >= 5)
        {
            GookTutorialManagerobj.GetComponent<GookTutorialManager>().End();
            StageCutton.GetComponent<Animation>().Play("CuttonDown"); //커튼 올리기
            gameObject.SetActive(false);
        }
    }
}
