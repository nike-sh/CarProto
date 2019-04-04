using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalRoadsRightLanes : MonoBehaviour
{
    private GameObject Car;
    

    void Start()
    {
        Car = GameObject.FindWithTag("Car");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CarCollider") || collision.CompareTag("HorizontalRoadsRight"))
        {
            Car.SendMessage("OnHorizontalRoadRight");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("CarCollider") || collision.CompareTag("HorizontalRoadsRight"))
        {
            Car.SendMessage("OffHorizontalRoadRight");
        }
    }



}