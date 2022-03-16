using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBG : MonoBehaviour
{
    private float length;
    private float startPos;
    public GameObject camera;
    public GameObject image;
    private float speed = 0.5f;
    private Vector2 direction = new Vector2(-1,0);
    private Vector2 velocity;

    void Update()
    {
        velocity = direction * speed; 
    }

    private void FixedUpdate()
    {
        Vector2 pos = image.transform.position;
        pos += velocity * Time.fixedDeltaTime;

        image.transform.position = pos; 
    }
}
