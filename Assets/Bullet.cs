//bullet

//libraries used
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class of bullet
public class Bullet : MonoBehaviour
{
    //vector type variable for defining the direction which the bullet is going to move
    public Vector2 direction = new Vector2(1, 0);
    //vector type variable to define the velocity of the bullet
    public Vector2 velocity;
    //variable to define how fast the bullet is going to move
    public float speed = 6;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        //define the speed and direction which the bullet is going to take
        velocity = direction * speed;
        //variable to get and save the position of the bullet
        Vector2 pos = transform.position;
        //statement to destroy the bullet after it gets out of the scene
        if (pos.x > 17.9f)
        {
            //method called to destroy the bullet
            Destroy(gameObject);
        }
    }
    //same as update method
    private void FixedUpdate()
    {
        //variable to get and save the position of the bullet
        Vector2 pos = transform.position;
        //save the new position of the bullet by adding the velocity since last frame
        pos += velocity * Time.fixedDeltaTime;
        //give the new position to the bullet
        transform.position = pos;
    }
}