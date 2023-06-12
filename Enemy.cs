using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public int Points;
    public float chance;
    
    public float speed = 5.0f;
    public int numShots = 3; // Quantidade de tiros necessários para teleportar
    public int numShotsTaken = 0; // Contador de tiros
    public List<GameObject> powerupPrefabs; // Lista de prefabs dos power-ups
    private Vector3 oldPosition; // Variável para armazenar a posição anterior
    public AudioSource audioSource;
    public GameObject explosao;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shoot"))
        {
            PlayAudio();
            Destroy(other.gameObject);

            numShotsTaken++; // Incrementa o contador de tiros
            if (numShotsTaken >= numShots) // Verifica se a quantidade de tiros necessários foi atingida
            {
                oldPosition = transform.position; // Armazena a posição anterior
                 Instantiate(explosao, transform.position, Quaternion.identity);
                Destroy(gameObject);
                numShotsTaken = 0; // Reinicia o contador de tiros
                Points = Points + 1;
                

                // Verifica se deve criar o item na posição anterior
                if (Random.value < chance)
                {
                    int randomIndex = Random.Range(0, powerupPrefabs.Count);
                    GameObject selectedPowerupPrefab = powerupPrefabs[randomIndex];
                    Instantiate(selectedPowerupPrefab, oldPosition, Quaternion.identity);
                }
            }
        }   
         if (other.CompareTag("ShootBzk"))
        {
            PlayAudio();
            Destroy(other.gameObject);

            numShotsTaken++; // Incrementa o contador de tiros
            if (numShotsTaken >= 1) // Verifica se a quantidade de tiros necessários foi atingida
            {
                oldPosition = transform.position; // Armazena a posição anterior
                 Instantiate(explosao, transform.position, Quaternion.identity);
                Destroy(gameObject);
                numShotsTaken = 0; // Reinicia o contador de tiros
                Points = Points + 1;
                

                // Verifica se deve criar o item na posição anterior
                if (Random.value < chance)
                {
                    int randomIndex = Random.Range(0, powerupPrefabs.Count);
                    GameObject selectedPowerupPrefab = powerupPrefabs[randomIndex];
                    Instantiate(selectedPowerupPrefab, oldPosition, Quaternion.identity);
                }
            }
        }

         if (other.CompareTag("SniperShoot"))
        {
            PlayAudio();
            Destroy(other.gameObject);

            numShotsTaken++; // Incrementa o contador de tiros
            if (numShotsTaken >= 1) // Verifica se a quantidade de tiros necessários foi atingida
            {
                oldPosition = transform.position; // Armazena a posição anterior
                 Instantiate(explosao, transform.position, Quaternion.identity);
                Destroy(gameObject);
                numShotsTaken = 0; // Reinicia o contador de tiros
                Points = Points + 1;
                

                // Verifica se deve criar o item na posição anterior
                if (Random.value < chance)
                {
                    int randomIndex = Random.Range(0, powerupPrefabs.Count);
                    GameObject selectedPowerupPrefab = powerupPrefabs[randomIndex];
                    Instantiate(selectedPowerupPrefab, oldPosition, Quaternion.identity);
                }
            }
        }
    }

    void Update()
    {
        
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void PlayAudio()
    {
        if (audioSource != null)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
                Invoke("StopAudio", 3.0f);
            }
        }
    }

    public void StopAudio()
    {
        if (audioSource != null)
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}
