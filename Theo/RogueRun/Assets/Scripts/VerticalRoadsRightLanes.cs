using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalRoadsRightLanes : MonoBehaviour
{
    private GameObject Car;

    void Start()
    {
        Car = GameObject.FindWithTag("Car");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CarCollider") || collision.CompareTag("VerticalRoadsRight"))
        {
            Car.SendMessage("OnVerticalRoadRight");
        }
    }


    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("CarCollider") || collision.CompareTag("VerticalRoadsRight"))
        {
            Car.SendMessage("OffVerticalRoadRight");
        }
    }

}