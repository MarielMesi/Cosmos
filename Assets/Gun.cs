//gun

//libraries used
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//gun class
public class Gun : MonoBehaviour
{
    //take methods of bullet from bullet
    public Bullet bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //shoot method
    public void Shoot()
    {
        //instantiate bullet when shoot method is called
        GameObject go = Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
    }
}