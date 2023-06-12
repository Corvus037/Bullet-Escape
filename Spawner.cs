using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float Time;
    public GameObject obj;
   
    void Start()
    {
        Invoke("Spawn",Time);
    }

   
    void Update()
    {
        
    }

    void Spawn(){

        Instantiate(obj, transform.position, transform.rotation);
        Invoke("Spawn", Time);
    }
}
