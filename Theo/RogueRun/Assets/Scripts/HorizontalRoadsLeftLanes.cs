using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalRoadsLeftLanes : MonoBehaviour
{
    private GameObject Car;

    void Start()
    {
        Car = GameObject.FindWithTag("Car");
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CarCollider") || collision.CompareTag("HorizontalRoadsLeft"))
        {
            Car.SendMessage("OnHorizontalRoadLeft");
            Debug.Log("OnHorizontal Road");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("CarCollider") || collision.CompareTag("HorizontalRoadsLeft"))
        {
            Car.SendMessage("OffHorizontalRoadLeft");
            Debug.Log("OffHorizontalRoad");
        }
    }

}