using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpikes : MonoBehaviour
{
    [SerializeField]
    GameObject Spikes;
    [SerializeField]
    GameObject Car;



    Vector3 pos;
    
    public Collider2D col;
    float DestroyTimerValue = 2f;
    float DestroyTimer;
    bool triggerDestroyTimer;
    bool changedPositionOnce;



    // Start is called before the first frame update
    void Start()
    {
        Spikes.SetActive(false);
        triggerDestroyTimer = false;
        changedPositionOnce = false;
        DestroyTimer = DestroyTimerValue;
    }

    void Update()
    {
        
        if (triggerDestroyTimer == true)
        {
            DestroyTimer -= Time.deltaTime;
            if (DestroyTimer < 0)
            {
                Car.SendMessage("SpikesArentActive");
                Spikes.SetActive(false);
                DestroyTimer = DestroyTimerValue;
                triggerDestroyTimer = false;
                ChangePosition();
                changedPositionOnce = true;
            }
        }
        
        

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CarCollider") || collision.CompareTag("SpawnSpikes"))
        {
            Spikes.SetActive(true);
            Car.SendMessage("SpikesAreActive");
            

        }
    }


    void DestroyTimerTrue()
    {
        triggerDestroyTimer = true;
    }

    void ChangePosition()
    {
        pos = transform.position;
        pos.x = -14f;
        pos.y = 20.24f;
        transform.position = pos;
        if(changedPositionOnce)
        {
            Destroy(Spikes);
            Destroy(this);
        }
        
    }


}
