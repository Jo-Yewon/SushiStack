using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDragCat : MonoBehaviour
{
    public float CatPositionX, FirstYPosition;
    public int firstPlate = 0, DishCount = 0;
    public Rigidbody2D rb;

    private bool moveAllowed = false;
    private GameObject catcollider;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        catcollider = gameObject.transform.GetChild(0).gameObject;
    }

    //30초마다 새로운 고양이로 바뀌면 실행될 함수,
    void OnEnable()
    {
        CatInit();
    }

    public void CatInit()
    {
        firstPlate = 0;
        DishCount = 0;
    }

    void Update()
    {
        GameObject[] Gobj = GameObject.FindGameObjectsWithTag("GreenPlate");
        GameObject[] Bobj = GameObject.FindGameObjectsWithTag("BluePlate");

        transform.rotation = Quaternion.Euler(0, 0, 0);

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            switch (touch.phase)
            {

                case TouchPhase.Began:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        CatPositionX = touchPos.x - transform.position.x;

                        moveAllowed = true;

                        rb.freezeRotation = true;
                        rb.velocity = new Vector2(0, 0);
                        rb.gravityScale = 0;
                    }
                    break;
                case TouchPhase.Moved:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos) && moveAllowed)
                    {

                        rb.MovePosition(new Vector2(touchPos.x - CatPositionX, touchPos.y));

                        for (int i = 0; i < Gobj.Length; i++)
                        {
                            GuestItemCollider plate = Gobj[i].GetComponent<GuestItemCollider>();

                            if (plate.rb.isKinematic == true)
                                plate.rb.MovePosition(new Vector2(touchPos.x - CatPositionX, plate.YPosition));

                        }
                        for (int i = 0; i < Bobj.Length; i++)
                        {
                            GuestItemCollider plate = Bobj[i].GetComponent<GuestItemCollider>();

                            if (plate.rb.isKinematic == true)
                                plate.rb.MovePosition(new Vector2(touchPos.x - CatPositionX, plate.YPosition));

                        }
                    }
                    break;

                case TouchPhase.Ended:
                    rb.velocity = new Vector2(0, 0);

                    moveAllowed = false;
                    rb.freezeRotation = false;
                    rb.gravityScale = 0;
                    break;
            }

        }
    }
}
