using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barril : MonoBehaviour

{
    public float speed;
    public float destroyDelay;

    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    }

