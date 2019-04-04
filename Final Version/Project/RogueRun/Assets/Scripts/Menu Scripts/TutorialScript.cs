using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialScript : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
      if(collision.CompareTag("CarCollider"))
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                TutorialToOne();
                Time.timeScale = 1f;
            }
            
        }
    }

 

    public void TutorialToOne()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
