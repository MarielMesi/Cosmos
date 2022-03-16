using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidSpawner : MonoBehaviour
{
  public Transform[] spawnLocations;
  public Astroid astroid;
  private float rndTimer = 5;


  // Start is called before the first frame update
  void Start()
  {
  
  }

  // Update is called once per frame
  void Update()
  {
    FixTime();

    if (rndTimer <= 0)
    {
      int randLocation = Random.Range(0, spawnLocations.Length);
      Instantiate(astroid, spawnLocations[randLocation].position, transform.rotation);
      RandomizeTimer();
    }

  }

  private void FixTime() 
  {
    rndTimer = rndTimer -0.016f;
  }

  private void RandomizeTimer()
  {
    rndTimer = Random.Range(6, 10);
  }

}