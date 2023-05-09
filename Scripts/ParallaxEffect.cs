using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public float parallaxSpeed = 0.02f;
    public Transform Background;
    private Vector3 lastCameraPosition;
    
    private void Start()
    {
        lastCameraPosition = transform.position;
    }

    private void Update()
    {
        float deltaX = transform.position.x - lastCameraPosition.x;
        Background.position += new Vector3(deltaX * parallaxSpeed, 0f, 0f);
        lastCameraPosition = transform.position;
    }
}