using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlateManager : MonoBehaviour
{
    public GameObject RedPlate;
    public GameObject tempItemArray;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("DropCoroutine1");
    }

    void Drop()
    {
        GameObject Instance =
            Instantiate(RedPlate, transform.position, transform.rotation) as GameObject;
        Instance.transform.SetParent(tempItemArray.transform, false);
        Instance.SetActive(true);
    }

    IEnumerator DropCoroutine1() //1초 마다 떨어뜨리기
    {
        while (true)
        {
                yield return new WaitForSeconds(1f);
                Drop();
                Debug.Log("DRop");
        }
    }
}
