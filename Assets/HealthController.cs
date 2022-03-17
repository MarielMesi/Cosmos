//hp controller

//libraries used
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//hp controller class
public class HealthController : MonoBehaviour
{
    //variable to define players hp
    public int playerHealth;
    //variable to define players  max hp
    public int numofhearts;
    //variable to define image when hp is full
    public Sprite fullHP;
    //variable to define image when hp is empty
    public Sprite emptyHP;

    //array to define hearts image
    [SerializeField] private Image[] hearts;

    // Update is called once per frame
    void Update()
    {
        //statement to give player the ammout of defined hp
        if(playerHealth > numofhearts)
        {
            //give the players hp the ammount of hearts defined
            playerHealth = numofhearts;
        }

        //statement for to loop htrough the hp length to show empty of full hp heart
        for (int i = 0; i < hearts.Length; i++)
        {
            //statement if to show full hp image if players hp is as much as hearts defined
            if (i < playerHealth)
            {
                //show full hp image in array defined
                hearts[i].sprite = fullHP;
            }
            //statement else to show empty hp image if players hp is as much as hearts defined
            else
            {
                //show empty hp image in array defined
                hearts[i].sprite = emptyHP;
            }
            //statement if to show heart to player if the number of hearts is inside of the hearts defined
            if (i < numofhearts)
            {
                //show heart in array
                hearts[i].enabled = true;
            }
            //statement else to not show heart to player if the number of hearts is outside of the hearts defined
            else
            {
                //do not show heart in array
                hearts[i].enabled = false;
            }
        }
    }
}
