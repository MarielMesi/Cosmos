//player ship

//libraries used
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//player ship class
public class Ship : MonoBehaviour
{
    //array list of the player ship guns
    Gun[] guns;
    //variable to define the speed of the players ship
    float moveSpeed = 6;
    //bool variable to move up when true
    bool moveUp;
    //bool variable to move down when true
    bool moveDown;
    //bool variable to move left when true
    bool moveLeft;
    //bool variable to move right when true
    bool moveRight;
    //bool variable to shoot when true
    bool shoot;

    // Start is called before the first frame update
    void Start()
    {
        //get the class gun in the guns ship
        guns = transform.GetComponentsInChildren<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
        //move up when up arrow or w is pressed
        moveUp = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        //move down when down arrow or s is pressed
        moveDown = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
        //move left when left arrow or a is pressed
        moveLeft = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        //move right when right arrow or d is pressed
        moveRight = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
        //shoot when space or left click is pressed
        shoot = Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0);
       
       //statement if to define what happens if shoot if true
        if (shoot)
        {
            //make shoot false after every click
            shoot = false;
            //shoot the bullet in every gun the player ship has
            foreach(Gun gun in guns)
            {
                //call shoot method from ships gun
                gun.Shoot();
            }
        }
    }
    //same as update method
    private void FixedUpdate()
    {
        //variable to get and save the position of the players ship
        Vector2 pos = transform.position;
        //variable defining the movement ammount with speed and the time passed since last frame
        float moveAmount = moveSpeed * Time.fixedDeltaTime;
        //vector type variable move which is started as 0
        Vector2 move = Vector2.zero;

        //statement if move up is true then players ship moves the movement ammount defined
        if(moveUp)
        {
            //define the ammount the players ship is going to move
            move.y += moveAmount;
        }
        //statement if move down is true then players ship moves the movement ammount defined
        if (moveDown)
        {
            //define the ammount the players ship is going to move
            move.y -= moveAmount;
        }
        //statement if move left is true then players ship moves the movement ammount defined
        if (moveLeft)
        {
            //define the ammount the players ship is going to move
            move.x -= moveAmount;
        }
        //statement if move right is true then players ship moves the movement ammount defined
        if (moveRight)
        {
            //define the ammount the players ship is going to move
            move.x += moveAmount;
        }

        //decrease the moving ammout speed of the players ship if the moving magnitude becomes high when moving sideways

        //define movement magnitude by calculating the moved position of players ship
        float moveMagnitude = Mathf.Sqrt(move.x * move.x + move.y * move.y);
        //statement if the movement magnitude is higher than the moving ammount defined decrease it
        if(moveMagnitude > moveAmount)
        {
            float ratio = moveAmount / moveMagnitude;
            move *= ratio;
        }
        //change the posisiton of players ship by the movement ammount defined
        pos += move;
        
        //statement if when the  players ship reaches the corner of our screen
        if(pos.x <= 14.86f)
        {
            //give position to the players ship to stop where we want
            pos.x = 14.86f;
        }
        //statement if when the  players ship reaches the corner of our screen
        if (pos.x >= 29.96f)
        {
            //give position to the players ship to stop where we want
            pos.x = 29.96f;
        }
        //statement if when the  players ship reaches the corner of our screen
        if (pos.y <= -0.5f)
        {
            //give position to the players ship to stop where we want
            pos.y = -0.5f;
        }
        //statement if when the  players ship reaches the corner of our screen
        if (pos.y >= 8.42f)
        {
            //give position to the players ship to stop where we want
            pos.y = 8.42f;
        }

        //give the new position to the players ship ship
        transform.position = pos;
    }
}