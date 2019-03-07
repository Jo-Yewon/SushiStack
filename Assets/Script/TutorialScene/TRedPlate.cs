using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRedPlate : MonoBehaviour
{
    public GameObject MyLuckyCatPanel, RedPlatePanel, stageCutton;
    private GameObject platecollider;
 
    public void Awake()
    {
        platecollider = gameObject.transform.GetChild(0).gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bottom"))
        {
            gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("CatCollider"))
        {
            MyLuckyCatPanel.SetActive(true);
            RedPlatePanel.SetActive(false);
            stageCutton.GetComponent<Animation>().Play("CuttonDown"); //커튼 내리기
        }
    }
}
