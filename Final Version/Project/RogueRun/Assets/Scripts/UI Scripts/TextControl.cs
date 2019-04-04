using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextControl : MonoBehaviour
{
    public Text carsVoice;
    float TextTimer;
    float TextTimerValue = 2f;
    
    private void Start()
    {
        carsVoice.text = " ";
        TextTimer = TextTimerValue;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("CarCollider") || collision.CompareTag("textTrigger(1)"))
        {

            carsVoice.text = "Hello! I am the AI of the car you are about to drive and I'm going to guide you through this short tutorial!\n\"Press and hold the right arrow key to continue\"";
            TextTimer -= Time.deltaTime;



        }
        if (collision.CompareTag("CarCollider") || collision.CompareTag("textTrigger(2)"))
        {

            carsVoice.text = " I can detect spikes nearby! When you see them on your lane, dodge them by pressing the \"E\" button!";
        }
        if (collision.CompareTag("CarCollider") || collision.CompareTag("textTrigger(3)"))
        {
            carsVoice.text = "Note: The dodge has 1 second cooldown.";
        }
        if (collision.CompareTag("CarCollider") || collision.CompareTag("textTrigger(4)"))
        {
            carsVoice.text = "Can you see that?!";



            TextTimer -= Time.deltaTime;
            Debug.Log(TextTimer);
            if (1.8f >= TextTimer && TextTimer >= 1.3f)
            {
                carsVoice.text = "Oh, you can't see that far..";

            }
            if (1.3f >= TextTimer && TextTimer >= 0.5f)
            {
                carsVoice.text = "An unknown vehicle is slowly approaching us and it doesn't seem friendly at all!";

            }
            if (0.5 >= TextTimer)
            {
                carsVoice.text = "\"Press X to shoot\" ";

            }
        }

        if (collision.CompareTag("CarCollider") || collision.CompareTag("textTrigger(5)"))
        {
            carsVoice.text = "\"That was the end of the tutorial - Press \"Space\" to continue to Level 1 \" ";
        }
    }
 

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("CarCollider") || collision.CompareTag("textTrigger(1)"))
        {
            carsVoice.text = " ";
            TextTimer = TextTimerValue;
        }
        if (collision.CompareTag("CarCollider") || collision.CompareTag("textTrigger(2)"))
        {
            carsVoice.text = " ";
            TextTimer = TextTimerValue;
        }
        if (collision.CompareTag("CarCollider") || collision.CompareTag("textTrigger(3)"))
        {
            carsVoice.text = " ";
            TextTimer = TextTimerValue;
        }
       

    }


}
