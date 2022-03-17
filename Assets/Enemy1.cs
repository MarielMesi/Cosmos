//enemy

//libraries used
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class of enemy
public class Enemy1 : MonoBehaviour
{
    //array list of the ships guns
    EnemyGun[] guns;
    //vector type variable for defining the direction which the enemy ship is going to move
    private Vector2 direction = new Vector2(0, 1);
    //vector type variable for defining the direction on +y axes which the enemy ship is going to move
    private Vector2 directionup = new Vector2(0, 1);
    //vector type variable for defining the direction on -y axes which the enemy ship is going to move
    private Vector2 directiondown = new Vector2(0, -1);
    //vector type variable to define the velocity of the enemy ship
    private Vector2 velocity;
    //variable to define how fast the enemy ship is going to move
    private float speed = 4;
    //boolean variable to shoot bullets
    bool shoot;


    // Start is called before the first frame update
    void Start()
    {
        //get the class enemy gun in the guns ship
        guns = transform.GetComponentsInChildren<EnemyGun>();
    }

    // Update is called once per frame
    void Update()
    {
        //define the speed and direction which the enemy ship is going to take
        velocity = direction * speed;
        //shoot bullet from gun when space or left click is pressed
        shoot = Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0);

        //statement if to define what happens if shoot if true
        if (shoot)
        {
            //make shoot false after every click
            shoot = false;
            //shoot the bullet in every gun the ship has
            foreach (EnemyGun gun in guns)
            {
                //call shoot method from enemy gun
                gun.Shoot();
            }
        }
    }

    //same as update method
    private void FixedUpdate()
    {
        //variable to get and save the position of the enemy ship
        Vector2 pos = transform.position;
        //statement if when the ship reaches the top corner of our screen
        if (pos.y >= 9.5f)
        {
            //change the direction of the object when corner reached
            direction = directiondown;
            //give position to the ship to start moving from where we want
            pos.y = 9.5f;
        }

        //statement if when the ship reaches the bottom corner of our screen
        if (pos.y <= 0.7f)
        {
            //change the direction of the object when corner reached
            direction = directionup;
            //give position to the ship to start moving from where we want
            pos.y = 0.7f;
        }

        //save the new position of the enemy ship by adding the velocity since last frame
        pos += velocity * Time.fixedDeltaTime;
        //give the new position to the enemy ship
        transform.position = pos;
    }
}