using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparencyTrigger : MonoBehaviour {
    [SerializeField]
    GameObject Building;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CarCollider") || collision.CompareTag("TransparencyBox"))
        {
            Building.SendMessage("StartAnimation");
            
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("CarCollider") || collision.CompareTag("TransparencyBox"))
        {
            Building.SendMessage("StopAnimation");
        }
    }




}
