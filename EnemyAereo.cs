using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAereo : MonoBehaviour
{
    public int life = 20;
    public GameObject explosao;
    public GameObject granada;
    public float speed = 5.0f;
    public AudioSource audioSource;
    public float tps;
    private float LastShoot = 0f;


    void Start()
    {   
        tps = tps*Time.deltaTime*60;
    }

    // Update is called once per frame
    void Update()
    {       
        if (Time.time > LastShoot + 1f / tps)
        {
            Instantiate(granada, transform.position, Quaternion.identity);
            LastShoot = Time.time;
        }
        
        if (life <= 0){
            Instantiate(explosao, transform.position, Quaternion.identity);
            Destroy(gameObject);
            
        }

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shoot"))
        {   
            PlayAudio();
            life--;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("ShootBzk"))
        {
            PlayAudio();
            Destroy(other.gameObject);
            life = life - 20;
        }
        
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
