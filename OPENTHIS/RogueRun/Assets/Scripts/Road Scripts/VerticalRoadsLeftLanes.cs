using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalRoadsLeftLanes : MonoBehaviour
{
    private GameObject Car;

    void Start()
    {
        Car = GameObject.FindWithTag("Car");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CarCollider") || collision.CompareTag("VerticalRoadsLeft"))
        {
            Car.SendMessage("OnVerticalRoadLeft");
        }
    }


    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("CarCollider") || collision.CompareTag("VerticalRoadsLeft"))
        {
            Car.SendMessage("OffVerticalRoadLeft");
        }
    }

}
