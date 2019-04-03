using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolingEnemyEngineL : MonoBehaviour
{
    //L at the end stands for Linear as in "Linear Patroling"
    private float speed = 5;
    private int health;

    [SerializeField]
    Transform[] nodes;

    Rigidbody2D EnemyRb;

    private int currentNode;
    private int numberOfNodes;

    private float shootingDistance = 4.4f;
    private bool enemyIsShooting;
    private float shootingTime;
    private float shootingTimeValue = 0.75f;


    
    
    public Transform player;
    public GameObject projectile;



    void Start()
    {
        EnemyRb = GetComponent<Rigidbody2D>();
        health = 75;

        currentNode = 0;
        numberOfNodes = nodes.Length;


        enemyIsShooting = false;
        shootingTime = shootingTimeValue;
        
        
        
    }



    void Update()
    {
        
        Patrol();
        Death();
        Shoot();
    }




    void Patrol()
    {
        if(enemyIsShooting == false)
        {
            EnemyRb.transform.position = Vector2.MoveTowards(EnemyRb.transform.position, nodes[currentNode].position, speed * Time.deltaTime);

            if (Vector2.Distance(EnemyRb.transform.position, nodes[currentNode].position) < 0.001f)
            {
                if (currentNode < numberOfNodes - 1)
                {
                    currentNode += 1;
                    Debug.Log(currentNode);
                }

                else if (currentNode == numberOfNodes - 1)
                {
                    Debug.Log("lastnode");
                    currentNode = 0;
                }
            }
        } else if(enemyIsShooting == true)

        {
            transform.position = this.transform.position;
        }
        
    }



    void Shoot()
    {
        
        if (Vector2.Distance(transform.position, player.position) < shootingDistance)
        {

            enemyIsShooting = true;

            if(shootingTime <= 0)
            {
                Instantiate(projectile, transform.position,     Quaternion.identity);
                shootingTime = shootingTimeValue;
            }
            else
            {
                shootingTime -= Time.deltaTime;
            }
            
        }


        if (Vector2.Distance(transform.position, player.position) > shootingDistance)
        {
            enemyIsShooting = false;
        }

    }



    void Death()
    {
        if(health == 0)
        {
            Destroy(gameObject);
        }
        
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            health -= 25;
        }

    }

}
