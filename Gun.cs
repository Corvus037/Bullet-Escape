using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    
    public GameObject Shoot;
    public Transform gun;
    public float tps;
    private float LastShoot = 0f;

    void Start()
    {
        tps = tps*Time.deltaTime*60;
    }

    
    void Update()
    {
        
        if (Time.time > LastShoot + 1f / tps)
        {
       Instantiate (Shoot, gun.position, gun.rotation);
       LastShoot = Time.time;
        }

    }

   
}

