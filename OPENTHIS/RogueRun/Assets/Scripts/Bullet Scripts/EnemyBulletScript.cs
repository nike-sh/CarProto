using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    float speed = 5f;

    private Rigidbody2D rb;

    private Transform target;

    private Vector2 moveDirection;

    private GameObject healthbar;
    



    
    // Start is called before the first frame update
    void Start()
    {
        healthbar = GameObject.FindGameObjectWithTag("Healthbar");
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Car").transform;
        moveDirection = (target.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 1f);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("CarCollider"))
        {
            healthbar.SendMessage("EnemyDamage");
            Destroy(gameObject);
        }
    }
}
