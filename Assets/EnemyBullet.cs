//enemy bullet

//libraries used
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//enemy bullet class
public class EnemyBullet : MonoBehaviour
{
    //vector type variable for defining the direction which the enemy bullet is going to move
    public Vector2 direction = new Vector2(1, 0);
    //vector type variable to define the velocity of the enemy bullet
    public Vector2 velocity;
    //variable to define how fast the enemy bullet is going to move
    public float speed = 6;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        //define the speed and direction which the enemy bullet is going to take
        velocity = direction * speed;
    }

    //same as update method
    private void FixedUpdate()
    {
        //variable to get and save the position of the enemy bullet
        Vector2 pos = transform.position;
        //save the new position of the enemy bullet by adding the velocity since last frame
        pos += velocity * Time.fixedDeltaTime;
        //give the new position to the enemy bullet
        transform.position = pos;
    }
}