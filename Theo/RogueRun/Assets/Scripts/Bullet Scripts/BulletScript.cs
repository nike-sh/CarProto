using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
    private float BulletTimer;
    private float BulletTimerValue = 0.5f;
    private float Damage = 25;
    [SerializeField]
    GameObject BulletPrefab;


    private float Health;
    Enemy Enemy;

    void Start()
    {
        BulletTimer = BulletTimerValue;
        Enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
        Health = Enemy.enemyHealth;
    }


    void Update()
    {
        BulletTimer -= Time.deltaTime;

        if(BulletTimer < 0 )
        {
            Destroy(BulletPrefab);
            BulletTimer = BulletTimerValue;
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("We hit the enemy with our gun!!");
            Health -= Damage;
            Destroy(BulletPrefab);
        }
    }

}
