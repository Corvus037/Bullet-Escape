using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosao : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroyer", 3.0f);
    }

    // Update is called once per frame
    void Destroyer()
    {
        Destroy(gameObject);
    }
}
