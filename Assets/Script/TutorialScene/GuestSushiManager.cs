using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0168


public class GuestSushiManager : MonoBehaviour
{
    public GameObject guestItemManagerObj, TutleItemManagerObj, GookItemManagerObj, FeverItemManagerObj;

    private TDragCat catmove;

    public void Start()
    {
        GameObject Cat = GameObject.Find("MovingCat");
        catmove = Cat.GetComponent<TDragCat>();
        //SushiNum = 0;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bottom"))
        {
            gameObject.SetActive(false);
        }

        if (catmove.firstPlate == 0 && collision.gameObject.CompareTag("CatCollider"))
        {
            try
            {
                TutleItemManagerObj.GetComponent<TurtleItemManager>().GetDishOrSushi();
            }
            catch (Exception e) { }
            try
            {
                guestItemManagerObj.GetComponent<GuestItemManager>().Get();
            }
            catch (Exception e) { }
            try
            {
                GookItemManagerObj.GetComponent<GookItemPanel>().GetSushi();
            }
            catch (Exception e) { }
            try
            {
                FeverItemManagerObj.GetComponent<FeverItemManager>().GetDishOrSushi();
            }
            catch (Exception e) { }
            gameObject.SetActive(false);

        }
        else if (catmove.firstPlate == 1 && collision.gameObject.CompareTag("PlateCollider"))
        {
            GameObject ob = collision.gameObject.transform.parent.gameObject;
            int count = ob.GetComponent<GuestItemCollider>().Count;

            if (count == 1)
            {
                try
                {
                    TutleItemManagerObj.GetComponent<TurtleItemManager>().GetDishOrSushi();
                }
                catch (Exception e) { }
                try
                {
                    guestItemManagerObj.GetComponent<GuestItemManager>().Get();
                }
                catch (Exception e) { }
                try
                {
                    GookItemManagerObj.GetComponent<GookItemPanel>().GetSushi();
                }
                catch (Exception e) { }
                try
                {
                    FeverItemManagerObj.GetComponent<FeverItemManager>().GetDishOrSushi();
                }
                catch (Exception e) { }
                gameObject.SetActive(false);
                gameObject.SetActive(false);
            }

        }
    }
}
