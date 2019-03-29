using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float playerhealth;
    public float currentHealth;
    public float numberOfLives;
    private float Lives;
    public bool isPlayerOutOfLives;
    public Transform respawnPoint;
    public GameObject enemy;
    Enemy Enemy;
    private float damageTaken;
    // Start is called before the first frame update
    void Start()
    {
        Lives = numberOfLives;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0 && Lives > 0)
        {
            Respawn();
            Lives--;
        }
        else
            return;

        if (Lives <= 0 && currentHealth <= 0)
            isPlayerOutOfLives = true;
        else
            isPlayerOutOfLives = false;
    }

    void Respawn()
    {
        GameObject.Destroy(gameObject);
        Instantiate(gameObject, respawnPoint.position, Quaternion.identity);
    }
}
