using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;

    private Transform player;
    private Vector2 target;

    GameObject Car;
    GameObject carDown;
    Enemy Enemy;
    PlayerHealth PlayerHealth;

    private float Health;
    private float Damage;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Car").transform;
        target = new Vector2(player.position.x, player.position.y);
        PlayerHealth = Car.gameObject.GetComponent<PlayerHealth>();
        Enemy = carDown.gameObject.GetComponent<Enemy>();

        Health = PlayerHealth.currentHealth;
        Damage = Enemy.enemyDamage;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
    }

    public void OnTriggerEnter2D(Collider2D CarCollider)
    {
            Health -= Damage;
            DestroyProjectile();
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

    public void HurtPlayer()
    {
        PlayerHealth.currentHealth -= Enemy.enemyDamage;
    }
  
}
