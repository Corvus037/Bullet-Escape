using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Transform spawnPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.HandleCollisionWithEmptyObject();
            }

            Instantiate(objectToSpawn, spawnPosition.position, spawnPosition.rotation);
            Destroy(gameObject); 
        }
    }
}