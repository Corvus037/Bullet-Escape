using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEnemy : MonoBehaviour
{
    [SerializeField] private GameObject Shoot;
    [SerializeField] private Transform gun;
    [SerializeField] private float tps;
    [SerializeField] private Transform facePlayer;

    private float lastShoot = 0f;

    private void Start()
    {
        tps = tps * Time.deltaTime * 60;
    }

    private void Update()
    {
        if (Time.time > lastShoot + 1f / tps)
        {
            if (facePlayer != null)
            {
                gun.LookAt(facePlayer);
            }

            Instantiate(Shoot, gun.position, gun.rotation);
            lastShoot = Time.time;
        }
    }
}