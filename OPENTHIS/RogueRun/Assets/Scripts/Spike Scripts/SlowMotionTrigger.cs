using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotionTrigger : MonoBehaviour
{

    private GameObject Car;
    [SerializeField]
    GameObject SpawnPoint;

    private bool CarRight;


    void Start()
    {
        CarRight = false;
        Car = GameObject.FindWithTag("Car");
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CarCollider") || collision.CompareTag("SlowmotionTrigger"))
        {
            if(CarRight == true)
            {
                Car.SendMessage("SlowMotionCol");
            }
            if(CarRight == false)

            {
                Car.SendMessage("SlowMotionColFalse");
                SpawnPoint.SendMessage("DestroyTimerTrue");
            }

        }
    }

    private void CarFacingRight()
    {
        CarRight = true;
    }

    private void CarNotFacingRight()
    {
        CarRight = false;
    }




}
