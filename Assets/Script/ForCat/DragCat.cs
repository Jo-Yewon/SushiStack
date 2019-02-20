using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCat : MonoBehaviour
{
    // Start is called before the first frame update

    public float CatPositionX, FirstYPosition;

    public int Modenumber;

    Rigidbody2D rb;

    public bool moveAllowed = false;

    public int firstPlate = 0;

    public int DishCount = 0;
    public int ItemCount = 0;
    public static int DishScore = 1;    // 피버타임때 점수를 2배로 만들기 위한 변수

    private GameObject catcollider;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //firstPlate = 0;
        //DishCount = 0; //OnEnable로 이동
        catcollider = GameObject.Find("CatCollider");
    }

    //30초마다 새로운 고양이로 바뀌면 실행될 함수,
    void OnEnable()
    {
        firstPlate = 0;
        DishCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //GameObject catcollider = GameObject.Find("CatCollider");
        GameObject[] Gobj = GameObject.FindGameObjectsWithTag("GreenPlate");
        GameObject[] Bobj = GameObject.FindGameObjectsWithTag("BluePlate");
        GameObject[] Robj = GameObject.FindGameObjectsWithTag("RedPlate");

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

                        for (int i = 0; i < Gobj.Length; i++) {
                            GreenPlate plate = Gobj[i].GetComponent<GreenPlate>();

                            if (plate.rb.isKinematic==true)
                                plate.rb.MovePosition(new Vector2(touchPos.x - CatPositionX, plate.YPosition));

                        }
                        for (int i = 0; i < Bobj.Length; i++)
                        {
                            BluePlate plate = Bobj[i].GetComponent<BluePlate>();

                            if (plate.rb.isKinematic == true)
                                plate.rb.MovePosition(new Vector2(touchPos.x - CatPositionX, plate.YPosition));

                        }
                        for (int i = 0; i < Robj.Length; i++)
                        {
                            RedPlate plate = Robj[i].GetComponent<RedPlate>();

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
