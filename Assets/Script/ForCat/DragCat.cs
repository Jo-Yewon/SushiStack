using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCat : MonoBehaviour
{
    // Start is called before the first frame update

    public float CatPositionX;

    Rigidbody2D rb;

    public bool moveAllowed = false;

    public int firstPlate = 0;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        firstPlate = 0;

        
   
    }

    // Update is called once per frame
    void Update()
    {
        GameObject catcollider = GameObject.Find("CatCollider");
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Plate");

        

        transform.rotation = Quaternion.Euler(0, 0, 0);

        if (Input.touchCount > 0) {

            Touch touch = Input.GetTouch(0);

            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase) {

                case TouchPhase.Began:
                    if (GetComponent < Collider2D>() == Physics2D.OverlapPoint(touchPos)) {
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

                        for (int i = 0; i < obj.Length; i++) {
                            SortPlate plate = obj[i].GetComponent<SortPlate>();

                            if (plate.rb.isKinematic==true)
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
