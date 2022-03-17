//enemy gun

//libraries used
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//enemy gun class
public class EnemyGun : MonoBehaviour
{
    //take methods of bullet from enemy bullet
    public EnemyBullet bullet;
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