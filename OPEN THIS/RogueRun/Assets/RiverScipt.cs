using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverScipt : MonoBehaviour {

    private GameObject healthbar;

    // Use this for initialization
    void Start () {
        healthbar = GameObject.FindGameObjectWithTag("Healthbar");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("RiverDeath"))
        {
            healthbar.SendMessage("RiverDamage");
            Debug.Log("We have drowned");
        }
    }
}
