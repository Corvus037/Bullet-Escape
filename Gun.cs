using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    Vector3 offset = new Vector3(1f, 0f, 0f);
    public GameObject Shoot;
    public GameObject ShootSniper;
    public Transform gun;
    public float tps;
    private float LastShoot = 0f;
    public float bonus;
    public GameObject glock;
    public GameObject mp9;
    public GameObject sniper;
    public GameObject doze;
    public GameObject bazuca;
    public bool pwp = false;
    public bool bzpwp = false;
    public GameObject shootbzk;
    public float bzktps = 3;
    public bool dozepwp = false;
    float dps;
    public bool sniperpwp = false;

    
    
    private void Awake() {
        dps = tps*Time.deltaTime*60;
        
    }
    
        
       
        
    
    

    
    void Update()
    {
        
        if (Time.time > LastShoot + 1f / dps)
        {
        if(bzpwp == true){
        
        Instantiate (shootbzk, gun.position, gun.rotation);
         LastShoot = Time.time;
        }else if(dozepwp == true)
        {
        Instantiate (Shoot, gun.position + offset, gun.rotation);
        LastShoot = Time.time;
         Instantiate (Shoot, gun.position , gun.rotation);
        LastShoot = Time.time;
        Instantiate (Shoot, gun.position - offset, gun.rotation);
        LastShoot = Time.time;
        }else if (sniperpwp == true){
        Instantiate (ShootSniper, gun.position, gun.rotation);
        LastShoot = Time.time;
        }else
        {
        Instantiate (Shoot, gun.position , gun.rotation);
        LastShoot = Time.time;
        }
        }

         if (Input.GetKey(KeyCode.Alpha4))
        {
            Bazuca();
        }
    }

      void OnTriggerEnter(Collider other) 
     {      if(bzpwp == false){
            if (other.gameObject.CompareTag("SmgPwp"))
       {    
            
            glock.SetActive(false);
            mp9.SetActive(true);
            dps = tps +bonus;

            Invoke("ReturnMp9" , 20f);
            
           
       }
        if (other.gameObject.CompareTag("DozePwp"))
       {    
            dps = tps - 2;
            glock.SetActive(false);
            doze.SetActive(true);
            dozepwp = true;

            Invoke("ReturnDZ" , 20f);
            
           
       }

        if (other.gameObject.CompareTag("SniperPwp"))
       {    
            
            glock.SetActive(false);
            sniper.SetActive(true);
            sniperpwp = true;
            dps = 3;

            Invoke("ReturnSniper" , 20f);
            
           
       }
     }

     }

    
    public void ReturnMp9()
    {
       dps = tps - bonus;
        glock.SetActive(true);
        mp9.SetActive(false);
        bazuca.SetActive(false);
    }

    public void Bazuca(){
        bazuca.SetActive(true);
        glock.SetActive(false);
        mp9.SetActive(false);
        bzpwp = true;
        dps = 3;
    }

     public void ReturnBzk()
    {
        bzpwp = false;
        glock.SetActive(true);
        mp9.SetActive(false);
        bazuca.SetActive(false);
        dps = tps;
    }
    public void ReturnDZ()
    {  
        dozepwp = false;
        dps = tps + 2;
        glock.SetActive(true);
        doze.SetActive(false);
    }

    public void ReturnSniper()
    {
        sniperpwp = false;
        glock.SetActive(true);
        sniper.SetActive(false);
        dps = tps;
    }
    

}

