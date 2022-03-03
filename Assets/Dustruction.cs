using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dustruction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet bullet = collision.GetComponent<Bullet>();
        if(bullet != null)
        {
            Destroy(gameObject);
            Destroy(bullet.gameObject);
        }
    }
}
