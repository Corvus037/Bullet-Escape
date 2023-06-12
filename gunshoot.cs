using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunshoot : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float destroyTime = 5.0f;

    private void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    void Update()
    {
        transform.Translate(transform.right * speed * Time.deltaTime);
    }
}
