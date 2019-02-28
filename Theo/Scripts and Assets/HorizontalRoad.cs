using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalRoad : MonoBehaviour
{
    public GameObject Car;
    public GameObject CarCollider;
   

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Car") || collision.CompareTag("HorizontalRoads"))
        {
            Car.SendMessage("OnHorizontalRoad");
            CarCollider.SendMessage("OnHorRoad");
            Debug.Log("OnHorizontal Road");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Car") || collision.CompareTag("HorizontalRoads"))
        {
            Car.SendMessage("OffHorizontalRoad");
            CarCollider.SendMessage("OffHorRoad");
            Debug.Log("OffHorizontalRoad");
        }
    }



}
