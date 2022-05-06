using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gbmove : MonoBehaviour
{
    //variables to get position and size of object and define its moving
    private BoxCollider2D boxCollider;
    private Rigidbody2D rb;
    private float width;
    private float speed = -3f;
    // Start is called before the first frame update
    void Start()
    {
        //define our variales from game component
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        //get size of object
        width = boxCollider.size.x;
        //define its moving speed
        rb.velocity = new Vector2(speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //if statement when our camera is out of background to reposition
        if(transform.position.x < -width/2)
        {
            Reposition();
        }
    }
    //function to reposition camera to its starting point
    private void Reposition()
    {
        Vector2 vector = new Vector2(width * 2f, 0);
        transform.position = (Vector2) transform.position + vector;
    }
}
