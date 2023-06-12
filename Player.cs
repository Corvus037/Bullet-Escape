using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float h;
    private float v;
    public float moveSpeed;
    public CharacterController cc;
    private bool speedBoostActive = false;
    private float speedBoostDuration = 5.0f;
    private float originalMoveSpeed;
    public GameObject objectToSpawn;
    public Transform spawnPosition;

    private int health = 100; // Vida inicial do jogador

    void Start()
    {
        cc = GetComponent<CharacterController>();
        originalMoveSpeed = moveSpeed;
    }

    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector3 myMove = new Vector3(h, 0, v);

        if (speedBoostActive)
        {
            cc.SimpleMove(myMove * (moveSpeed + 5));
        }
        else
        {
            cc.SimpleMove(myMove * moveSpeed);
        }

        cc.Move(myMove * moveSpeed * Time.deltaTime);
    }

    private IEnumerator ActivateSpeedBoost(float duration)
    {
        speedBoostActive = true;
        moveSpeed += 5;
        yield return new WaitForSeconds(duration);
        moveSpeed = originalMoveSpeed;
        speedBoostActive = false;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag("Barril"))
        {
            // Diminui 10 de vida do jogador
            health -= 10;

            // Verifica se o jogador ainda tem vida
            if (health <= 0)
            {
                // O jogador perdeu, execute as ações necessárias (game over, reiniciar, etc.)
                Debug.Log("Game Over");
            }
            

            // Destrua o objeto barril
            Destroy(hit.collider.gameObject);
        }
    }

    public void HandleCollisionWithEmptyObject()
    {
        
    }

    private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("SpeedBoost"))
    {
       
        StartCoroutine(ActivateSpeedBoost(speedBoostDuration));

        
        Destroy(other.gameObject);
    }
}
}