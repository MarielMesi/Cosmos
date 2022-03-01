using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    EnemyGun[] guns;


    private Vector2 direction = new Vector2(0, 1);
    private Vector2 directionup = new Vector2(0, 1);
    private Vector2 directiondown = new Vector2(0, -1);
    private Vector2 velocity;
    private float speed = 4;

    bool shoot;


    // Start is called before the first frame update
    void Start()
    {
        guns = transform.GetComponentsInChildren<EnemyGun>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity = direction * speed;
        shoot = Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0);
        if (shoot)
        {
            shoot = false;
            foreach (EnemyGun gun in guns)
            {
                gun.Shoot();
            }
        }
    }
    private void FixedUpdate()
    {
        Vector2 pos = transform.position;
        if (pos.y >= 9.5f)
        {
            direction = directiondown;
            pos.y = 9.5f;
        }

        if (pos.y <= 0.7f)
        {
            direction = directionup;
            pos.y = 0.7f;
        }

        pos += velocity * Time.fixedDeltaTime;
        transform.position = pos;
       
    }
}