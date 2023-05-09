using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunshoot : MonoBehaviour
{

    void Start(){
        Destroy(this.gameObject, 10.0f);

    }
   public float speed;
    void Update()
    {
        transform.Translate(speed * Time.deltaTime , 0 , 0);
    }

     private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que colidiu possui o componente "Destroyable"
        if (other.CompareTag("Player"))
        {
            // Destroi o objeto que colidiu
           
        }
         
    }
   
    }
