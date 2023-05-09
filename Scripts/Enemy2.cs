using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Enemy2 : MonoBehaviour
{
    public int Points;
    public Text Score;
    public float speed = 5.0f;
    public int numShots = 3; // Quantidade de tiros necessários para teleportar
    public int numShotsTaken = 0; // Contador de tiros
    public GameObject itemPrefab; // Prefab do item a ser criado
    private Vector3 oldPosition; // Variável para armazenar a posição anterior

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shoot"))
        {
            numShotsTaken++; // Incrementa o contador de tiros
            if (numShotsTaken >= numShots) // Verifica se a quantidade de tiros necessários foi atingida
            {
                oldPosition = transform.position; // Armazena a posição anterior
                Vector3 newPosition = new Vector3(54, -13, Random.Range(9,-5));
                transform.position = newPosition;
                numShotsTaken = 0; // Reinicia o contador de tiros
                Points = Points + 1;
                Score.text = "Score: " + Points;
                
                if (Points > 10)
                {
                    SceneManager.LoadScene("Win");
                }

                // Verifica se deve criar o item na posição anterior
                if (Random.value < 0.2f) // Chance de 20%
                {
                    Instantiate(itemPrefab, oldPosition, Quaternion.identity);
                }
            }
        }
    }

    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
}