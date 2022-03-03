using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public int playerHealth;
    public int numofhearts;
    public Sprite fullHP;
    public Sprite emptyHP;

    [SerializeField] private Image[] hearts;


    void Update()
    {
        if(playerHealth > numofhearts)
        {
            playerHealth = numofhearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < playerHealth)
            {
                hearts[i].sprite = fullHP;
            }
            else
            {
                hearts[i].sprite = emptyHP;
            }
            if (i < numofhearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
