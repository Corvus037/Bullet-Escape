using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Life : MonoBehaviour
{
    [SerializeField] private float vidaMaxima = 150;
    [SerializeField] private GameObject explosao;
    //[SerializeField] private Text vidas;

    private float vidaAtual;

    private void Awake() {
        vidaAtual = vidaMaxima;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.T)) {
            vidaAtual = Mathf.Clamp(vidaAtual + 10f, 0, vidaMaxima);
        }
        if (Input.GetKeyDown(KeyCode.G)) {
            vidaAtual = Mathf.Clamp(vidaAtual - 10f, 0, vidaMaxima);
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Vida"))
        {
            vidaAtual = Mathf.Clamp(vidaAtual = vidaMaxima, 0, vidaMaxima);
            Destroy(other.gameObject);
           // vidas.text = "Vidas: " + vidaAtual;
        }
        if (other.gameObject.CompareTag("ShootEnemy"))
        {   
            Destroy(other.gameObject);
            vidaAtual = Mathf.Clamp(vidaAtual - 10f, 0, vidaMaxima);
           // vidas.text = "Vidas: " + vidaAtual;
            PlayAudio();
            if (vidaAtual == 0)
            {
                SceneManager.LoadScene("GameOver");
            }

            if (other.gameObject.CompareTag("Barril"))
        {   
            Destroy(other.gameObject);
            vidaAtual = Mathf.Clamp(vidaAtual - 20f, 0, vidaMaxima);
           // vidas.text = "Vidas: " + vidaAtual;
            PlayAudio();
            if (vidaAtual == 0)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
        if (other.gameObject.CompareTag("Granada"))
        {   
            Destroy(other.gameObject);
            vidaAtual = Mathf.Clamp(vidaAtual - 10f, 0, vidaMaxima);
            Instantiate(explosao, transform.position, Quaternion.identity);
            PlayAudio();
            if (vidaAtual == 0)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }}

    //PROVISORIO 

    public AudioSource audioSource;

    public void PlayAudio()
    {
        if (audioSource != null)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();

                Invoke("StopAudio" , 3.0f);
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

    public float TaxaDeVida => vidaAtual / vidaMaxima;
}
