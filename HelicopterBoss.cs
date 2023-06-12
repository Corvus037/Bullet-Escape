using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HelicopterBoss : MonoBehaviour
{   
    [SerializeField] private float life;
    [SerializeField] private float dmg = 5;
    [SerializeField] private bool fase = false;
    [SerializeField] private float lifeTotal = 1000;
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private Transform[] routePoints;
    [SerializeField] private float distanceThreshold = 0.3f;
    [SerializeField] private Image healthBar;
    [SerializeField] private GameObject BossLife;
    [SerializeField] private float TaxaDeVida;
    [SerializeField] private string level;

    private int currentRouteId = 0;
     private void Awake(){

        BossLife.SetActive(true);
    }


    private void Start(){

        life = lifeTotal;
    }

    private void Update()
    {
        Vector3 direction = routePoints[currentRouteId].position - transform.position;
        direction.Normalize();
        transform.Translate(direction * Time.deltaTime * movementSpeed);

        if (Vector3.Distance(transform.position, routePoints[currentRouteId].position) < distanceThreshold){
            NextPoint();
        }

         if (Input.GetKeyDown(KeyCode.F)) {
           Dmg(10);
        }
        TaxaDeVida = life/lifeTotal;
    }  

    private void NextPoint()
    {
        currentRouteId = (currentRouteId + 1) % routePoints.Length;
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shoot")){
            Dmg(dmg);
            Fase2();
        }
        if (other.CompareTag("ShootBzk")){
            Dmg(lifeTotal);
            Fase2();
        }
         if (other.CompareTag("SniperShoot")){
            Dmg(dmg*2);
            Fase2();
        }
        
    }
    private void Fase2(){
          if(fase == false)
             {
                if(life <= lifeTotal/2)
                {
                    movementSpeed++;
                    fase = true;
                }
             } 
    }

    private void Dmg(float damage)
    {
        life -= damage;
        healthBar.fillAmount = TaxaDeVida;
         if (life <= 0)
            {
                SceneManager.LoadScene(level);
            }
    }
}



