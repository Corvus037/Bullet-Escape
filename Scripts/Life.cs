using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Life : MonoBehaviour
{
    public int life = 300;
    public Text vidas;

    void OnCollisionEnter(Collision Bullet)
    {
        if (Bullet.gameObject.CompareTag("Vida"))
        {
            if (life < 300)
            {
                life += 10;
                Destroy(Bullet.gameObject);
                vidas.text = "Vidas: " + life;
            }
        }
        else
        {
            life--;
            vidas.text = "Vidas: " + life;
            if (life < 1)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}
