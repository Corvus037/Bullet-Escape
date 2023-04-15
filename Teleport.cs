using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Teleport : MonoBehaviour
{
    public Transform teleportTarget; // objeto vazio para o qual será teleportado

    private void OnCollisionEnter(Collision collision)
    {
        // verifica se a colisão é com um objeto que tenha o nome "Enemy"
        if (collision.gameObject.name == "Enemy")
        {
            // teleporta o inimigo para a posição do objeto vazio
            collision.transform.position = teleportTarget.position;
        }
    }
}