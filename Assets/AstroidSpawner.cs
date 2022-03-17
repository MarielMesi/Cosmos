//asteroids random spawns

//libraries used
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class of spawner
public class AstroidSpawner : MonoBehaviour
{

  //array of 6 locations for asteroid to spawn
  public Transform[] spawnLocations;
  //object which is going to spawn
  public Astroid astroid;
  //variable for timing the spawns of asteroid
  private float rndTimer = 5;


  // Start is called before the first frame update
  void Start()
  {
  
  }

  // Update is called once per frame
  void Update()
  {
    //method called
    FixTime();

    //spawn asteroid in one of the 6 random locations randomly
    if (rndTimer <= 0)
    {
      //define the random variable which the asteroid is going to spawn 
      int randLocation = Random.Range(0, spawnLocations.Length);
      //spawn the asteroid
      Instantiate(astroid, spawnLocations[randLocation].position, transform.rotation);
      //randomize the timer method called
      RandomizeTimer();
    }

  }

  //method for choosing what time is the difference between every spawn
  private void FixTime() 
  {
    rndTimer = rndTimer -0.016f;
  }

  //method to randomize the timer in the range defined
  private void RandomizeTimer()
  {
    rndTimer = Random.Range(6, 10);
  }
}