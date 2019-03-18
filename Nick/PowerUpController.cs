using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour {
    [SerializeField]
    GameObject Car;
	// Use this for initialization
	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("CarCollider") || other.CompareTag("PowerUp"))
        {
            Debug.Log("ItWorks");
            Pickup();
        }

    }
    void Pickup()
    {
        Car.SendMessage("SpeedBoostTrigger"); //calls function in carcontroller
        Debug.Log("Powerup picked up");
    }

    void SpeedBoost()
    {
            Speed += 15f;
            PowerUpTimer -= Time.deltaTime;
            if (PowerUpTimer < 0)
            {
                Debug.Log("TimerWorks");
                Speed = SpeedValue;
                PowerUpTimer = PowerUpTimerValue;
            }

        //https://www.youtube.com/watch?v=CLSiRf_OrBk
    }
}
