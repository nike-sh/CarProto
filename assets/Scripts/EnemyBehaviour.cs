using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public float speed;
    public float followSpeed;
    private float waitTime;
    public float startWaitTime;
    private Transform target;
    public float followDistance;

    public Transform[] moveSpots;
    private int destPoints = 0;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        GotoNextPoint();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void GotoNextPoint()
    {
        if (moveSpots.Length == 0)
        return;
   
        agent.destination = moveSpots[destPoints].position;

        destPoints = (destPoints + 1) % moveSpots.Length;
    }
    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) < followDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, followSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, moveSpots[destPoints].position, speed * Time.deltaTime);
            if(Vector2.Distance(transform.position, moveSpots[destPoints].position) < 0.2f)
            {
                if(waitTime <= 0)
                {
                    GotoNextPoint();
                    waitTime = startWaitTime;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
        }
    }
}
