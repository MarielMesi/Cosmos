//destruction of object

//libraries used
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class of destruction
public class Dustruction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //method for using the collision phisics of object on trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //get the bullet component which the asteroid is going to be hit with
        Bullet bullet = collision.GetComponent<Bullet>();
        //statement if collision between asteroid and bullet happens
        if(bullet != null)
        {
            //destroy asteroid
            Destroy(gameObject);
            //destroy bullet
            Destroy(bullet.gameObject);
        }
    }
}