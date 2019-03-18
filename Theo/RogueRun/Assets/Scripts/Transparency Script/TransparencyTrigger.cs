using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparencyTrigger : MonoBehaviour {
    [SerializeField]
    GameObject Building1;



    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CarCollider") || collision.CompareTag("TransparencyBox"))
        {
            Building1.SendMessage("StartAnimation");
            
        }
    }


    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("CarCollider") || collision.CompareTag("TransparencyBox"))
        {
            Building1.SendMessage("StopAnimation");
        }
    }




}
