using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalRoad : MonoBehaviour
{
    public GameObject Car;
    public GameObject CarCollider;

   

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Car") || collision.CompareTag("VerticalRoads"))
        {
            Car.SendMessage("OnVerticalRoad");
            CarCollider.SendMessage("OnVerRoad");
            Debug.Log("OnVerticalRoad");
        }
    }


    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Car") || collision.CompareTag("VerticalRoads"))
        {
            Car.SendMessage("OffVerticalRoad");
            CarCollider.SendMessage("OffVerRoad"); 
            Debug.Log("OffVerticalRoad");
        }
    }

}
