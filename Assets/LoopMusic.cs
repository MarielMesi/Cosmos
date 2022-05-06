using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopMusic : MonoBehaviour
{
    // Update is called once per frame
    void Awake()
    {
        //method to not destroy audio in any case while game is open
        DontDestroyOnLoad(transform.gameObject);
    }
}