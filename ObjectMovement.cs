using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float speed = 1.0f; 
    public float resetPosition = -1.0f;

    private Vector3 initialPosition; 

    private void Start()
    {
        initialPosition = transform.position; 
    }

    private void Update()
    {
        
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        
        if (transform.position.x >= resetPosition)
        {
            
            transform.position = initialPosition;
        }
    }
}