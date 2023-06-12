using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn1 : MonoBehaviour
{
     public GameObject objectToSpawn;
     public GameObject spawnAereo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            objectToSpawn.SetActive(true);
            Destroy(spawnAereo); 
            Destroy(gameObject); 
        }
    }
}
