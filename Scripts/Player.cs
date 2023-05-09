using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float h;
    private float v;
    public float moveSpeed;
    public CharacterController cc;
    //public Rigidbody rb;
    
    
    void Start()
    {
       cc = GetComponent<CharacterController>();
       
    }

    
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        
        //rb.AddForce(h* moveSpeed, 0, v* moveSpeed);
        
        Vector3 myMove = new Vector3(h, 0, v);

       cc.SimpleMove(myMove*moveSpeed);
       cc.Move(myMove*moveSpeed*Time.deltaTime);
       // transform.position = transform.position +  new Vector3(h,0,v)* moveSpeed * Time.deltaTime;



    }
}
