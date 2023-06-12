using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
   

    private void OnCollisionEnter(Collision collision)
    {
        // verifica se a colisão é com um objeto que tenha o nome "Enemy"
        if (collision.gameObject.name == "Enemy")
        {
           Destroy(collision.gameObject);
        }
    }
}