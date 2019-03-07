using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestManager : MonoBehaviour
{
    public GameObject[] textArr1 = new GameObject[6], textArr2=new GameObject[5], textArr3 = new GameObject[2];
    public GameObject CatObj, Order;
    public GameObject button1;
    public GameObject stageCutton, RedPlatePanel;
    public GameObject guestItemManager;

    private readonly static float INTERVAL_TIME = 2f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Coroutine1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Coroutine1()
    {
        //처음 설명 3줄
        textArr1[0].SetActive(true);
        yield return new WaitForSeconds(1.5f);
        textArr1[0].SetActive(false);
        textArr1[1].SetActive(true);
        yield return new WaitForSeconds(INTERVAL_TIME);
        textArr1[1].SetActive(false);
        textArr1[2].SetActive(true);
        yield return new WaitForSeconds(INTERVAL_TIME);

        //고양이 올라오기
        CatObj.layer = LayerMask.NameToLayer("CatAppear");
        CatObj.GetComponent<Animation>().Play("CatUp");
        CatObj.GetComponent<AudioSource>().Play();

        //주문 말풍선 띄우기
        yield return new WaitForSeconds(0.6f);
        Order.SetActive(true);
        yield return new WaitForSeconds(0.6f);

        //설명 3줄
        textArr1[2].SetActive(false);
        textArr1[3].SetActive(true);
        yield return new WaitForSeconds(2f);
        textArr1[3].SetActive(false);
        textArr1[4].SetActive(true);
        yield return new WaitForSeconds(2.5f);
        textArr1[4].SetActive(false);
        textArr1[5].SetActive(true);
        yield return new WaitForSeconds(2.5f);
        button1.SetActive(true);

    }

    public void NextButton1Clicked()
    {
        textArr1[5].SetActive(false);
        button1.SetActive(false);
        StartCoroutine("Coroutine2");
    }

    IEnumerator Coroutine2()
    {
        //커튼 올리기
        stageCutton.GetComponent<Animation>().Play("CuttonUp"); //커튼 올리기
        yield return new WaitForSeconds(0.125f);
        CatObj.layer = LayerMask.NameToLayer("CatPlaying"); //초밥 뒤쪽으로 레이어 재배치
        yield return new WaitForSeconds(0.125f);
        Order.SetActive(false);

        //설명 4줄
        textArr2[0].SetActive(true);
        yield return new WaitForSeconds(2f);
        textArr2[0].SetActive(false);
        textArr2[1].SetActive(true);
        yield return new WaitForSeconds(2f);
        textArr2[1].SetActive(false);
        textArr2[2].SetActive(true);
        yield return new WaitForSeconds(3f);
        textArr2[2].SetActive(false);
        textArr2[3].SetActive(true);
        yield return new WaitForSeconds(3f);
        textArr2[3].SetActive(false);
        textArr2[4].SetActive(true);
        yield return new WaitForSeconds(2.5f);
        textArr2[4].SetActive(false);

        CatObj.GetComponent<TDragCat>().enabled = true; //이때부터 다시 고양이가 움직일 수 있도록
        guestItemManager.SetActive(true); //초밥과 접시 드랍도 시작
    }


    public GameObject tempArr1;

    public void GetStageEnd()
    {
        /*
        for (int i = 0; i < tempArr1.transform.childCount; i++)
            GameObject.Destroy(tempArr1.transform.GetChild(i));
            */
        StartCoroutine("Coroutine3");
    }

    IEnumerator Coroutine3()
    {
        //대사 3줄
        yield return new WaitForSeconds(0.5f);
        textArr3[0].SetActive(true);
        yield return new WaitForSeconds(1.5f);
        textArr3[0].SetActive(false);
        textArr3[1].SetActive(true);
        yield return new WaitForSeconds(INTERVAL_TIME);
        textArr3[1].SetActive(false);

        //고양이 초기화
        CatObj.SetActive(false);
        CatObj.SetActive(true);

        //시작
        stageCutton.GetComponent<Animation>().Play("CuttonUp"); //커튼 올리기
        yield return new WaitForSeconds(0.125f);
        RedPlatePanel.SetActive(true); //빨간 접시 내려오도록
    }
}
