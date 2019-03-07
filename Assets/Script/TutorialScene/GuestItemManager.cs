using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestItemManager : MonoBehaviour
{
    public GameObject[] DishAndSushi = new GameObject[4];
    public GameObject tempItemArray;
    public GameObject stageCutton;
    public GameObject MyGuestManager;

    private static float FALLING_INTERVAL = 1f; //떨어지는 시간 간격
    private int getNum;

    // Start is called before the first frame update
    void Start()
    {
        getNum = 0;
        StartCoroutine("DropCoroutine");
    }

    void Drop(int n)
    {
        GameObject Instance =
            Instantiate(DishAndSushi[n], transform.position, transform.rotation) as GameObject;
        Instance.transform.SetParent(tempItemArray.transform, false);
        Instance.SetActive(true);
    }

    IEnumerator DropCoroutine() //1초 마다 떨어뜨리기
    {
        while (true)
        {
            for (int i = 0; i < 4; i++)
            {
                yield return new WaitForSeconds(FALLING_INTERVAL);
                Drop(i);
            }
        }
        
    }

    public void Get()
    {
        getNum++;
        if (getNum >= 3)
        {
            stageCutton.GetComponent<Animation>().Play("CuttonDown"); //커튼 내리기
            Invoke("End", 0.125f);
        }
    }

    public void End()
    {
        MyGuestManager.GetComponent<GuestManager>().GetStageEnd();
        gameObject.SetActive(false);
    }
}
