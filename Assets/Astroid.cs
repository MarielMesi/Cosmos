//asteroid

//libraries used
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class of asteroid
public class Astroid : MonoBehaviour
{
    //vector type variable for defining the direction which the asteroid is going to move
    private Vector2 direction = new Vector2(-1,0);
    //vector type variable to define the velocity of the asteroid
    private Vector2 velocity;
    //variable to define how fast the asteroid is going to move
    private float speed = 4;
    //variable to define the asteroid
    private Astroid astroid;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        //define the speed and direction which the asteroid is going to take
        velocity = direction * speed;
    }
    //same as update method
    private void FixedUpdate()
    {
        //variable to get and save the position of the asteroid
        Vector2 pos = transform.position;
        //save the new position of the asteroid by adding the velocity since last frame
        pos += velocity * Time.fixedDeltaTime;
        //give the new position to the asteroid
        transform.position = pos;
    }
}