using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesDamage : MonoBehaviour {
    [SerializeField]
    GameObject HealthBar;

    void OnTriggerEnter2D(Collider2D collision)
    {
        HealthBar.SendMessage("SpikesDamage");
    }

}
