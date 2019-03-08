using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#pragma warning disable 0168

public class GuestItemCollider : MonoBehaviour
{
    public Rigidbody2D rb;
    public float YPosition;
    public GameObject Cat;
    public GameObject guestItemManagerObj, TutleItemManagerObj, FeverItemManagerObj;

    private GameObject platecollider;
    private TDragCat catmove;
    private int count = 0;

    public int Count { get => count; set => count = value; }

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

        catmove = Cat.GetComponent<TDragCat>();

        if (catmove.firstPlate == 0 && collision.gameObject.CompareTag("CatCollider"))
        {
            rb.isKinematic = true;
            rb.velocity = new Vector2(0, 0);

            try
            {
                gameObject.GetComponent<TFallingScript>().enabled = false;
            }
            catch (Exception e) { }
            try
            {
                gameObject.GetComponent<TFallingSlow>().enabled = false;
            }
            catch (Exception e) { }

            catmove.FirstYPosition = transform.position.y;
            YPosition = transform.position.y;
            catmove.firstPlate = 1;
            catmove.DishCount++;
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
                FeverItemManagerObj.GetComponent<FeverItemManager>().GetDishOrSushi();
            }
            catch (Exception e) { }
            count++;
        }
        else if (catmove.firstPlate == 1 && collision.gameObject.CompareTag("PlateCollider"))
        {
            rb.isKinematic = true;
            rb.velocity = new Vector2(0, 0);

            try
            {
                gameObject.GetComponent<TFallingScript>().enabled = false;
            }
            catch (Exception e) { }
            try
            {
                gameObject.GetComponent<TFallingSlow>().enabled = false;
            }
            catch (Exception e) { }

            if (count == 0)
            {
                YPosition = catmove.FirstYPosition + (catmove.DishCount * (0.2f));
            }
            count++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 2)
        {
            platecollider.SetActive(false);
            catmove.DishCount++;
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
                FeverItemManagerObj.GetComponent<FeverItemManager>().GetDishOrSushi();
            }
            catch (Exception e) { }
            count++;
            this.enabled = false;
        }
    }
}
