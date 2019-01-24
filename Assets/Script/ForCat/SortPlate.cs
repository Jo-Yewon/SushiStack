using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SortPlate : MonoBehaviour
{
 
    public Rigidbody2D rb;

    public float YPosition;

    private int count = 0;
    
      
    // Start is called before the first frame update
    void Start()
    {
        

        rb = GetComponent<Rigidbody2D>();    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject Cat = GameObject.Find("MiddleCat");
        DragCat catmove = Cat.GetComponent<DragCat>();
        if (catmove.firstPlate == 0&&collision.gameObject.CompareTag("CatCollider"))
        {
            rb.isKinematic = true;
            rb.velocity = new Vector2(0, 0);
            YPosition = transform.position.y;
            catmove.firstPlate = 1;
            count++;
        }
        else if (catmove.firstPlate == 1 && collision.gameObject.CompareTag("PlateCollider"))
        {
            rb.isKinematic = true;
            rb.velocity = new Vector2(0, 0);
            YPosition = transform.position.y;
            count++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameObject plate = this.gameObject;

        GameObject platecollider = plate.transform.GetChild(0).gameObject;

        if (count == 2) {
            platecollider.SetActive(false);
        }

        
       
    }
}
