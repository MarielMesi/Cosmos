//moving bg

//libraries used
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//moving bg class
public class MovingBG : MonoBehaviour
{
    //variable to define camera
    public GameObject camera;
    //variable to define image
    public GameObject image;
    //vector type variable for defining the direction which the asteroid is going to move
    private Vector2 direction = new Vector2(-1,0);
    //vector type variable to define the velocity of the asteroid
    private Vector2 velocity;
    //variable to define how fast the asteroid is going to move
    private float speed = 0.5f;

    //Update is called once per frame
    void Update()
    {
        //define the speed and direction which the asteroid is going to take
        velocity = direction * speed; 
    }

    //same as update method
    private void FixedUpdate()
    {
        //variable to get and save the position of the image
        Vector2 pos = image.transform.position;
        //save the new position of the image by adding the velocity since last frame
        pos += velocity * Time.fixedDeltaTime;
        //give the new position to the image
        image.transform.position = pos; 
    }
}