using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidSpawner : MonoBehaviour
{
    public Transform[] spawnLocations;
    public Astroid astroid;
     
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            int randLocation = Random.Range(0, spawnLocations.Length);

            Instantiate(astroid, spawnLocations[randLocation].position, transform.rotation);
        }
    }
}