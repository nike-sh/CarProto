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
    public Transform target;
    GameObject enemy;
    Enemy Enemy;
    private float damageTaken;
    // Start is called before the first frame update
    void Start()
    {
        Lives = numberOfLives;
        currentHealth = playerhealth;
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

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            Debug.Log("Ouch!! The enemyt shot us!");
            other.gameObject.GetComponent<Projectile>().HurtPlayer(); 
        }
    }

    void Respawn()
    {
        GameObject.Destroy(gameObject);
        Instantiate(target, respawnPoint.position, Quaternion.identity);
    }
}
