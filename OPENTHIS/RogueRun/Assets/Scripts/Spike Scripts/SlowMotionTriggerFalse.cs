using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotionTriggerFalse : MonoBehaviour
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
        if (collision.CompareTag("CarCollider") || collision.CompareTag("SlowMotionTriggerFalse"))
        {
            if(CarRight == true)
            {
                Car.SendMessage("SlowMotionColFalse");
                SpawnPoint.SendMessage("DestroyTimerTrue");
            }
            
            if(CarRight == false)
            {
                Car.SendMessage("SlowMotionCol");
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
