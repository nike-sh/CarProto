using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollider : MonoBehaviour
{
    bool HorRoad = true;
    bool VerRoad = false;

    void Update()
    {

       
            if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)))
            {
            if(VerRoad)
            {
                transform.eulerAngles = Vector3.forward * 90;
            }
                

            }
       
       
            if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)))
            {
          
            if (HorRoad)
            {
                transform.eulerAngles = Vector3.forward * 180;
            }
                

            }
       
  
    }

    void OnHorRoad()
    {
        HorRoad = true;
    }

    void OnVerRoad()
    {
        VerRoad = true;
    }
   
    void OffHorRoad()
    {
        HorRoad = false;
    }

    void OffVerRoad()
    {
        VerRoad = false;
    }


   

}

/*&& && transform.rotation.eulerAngles.y == 0
 transform.rotation.eulerAngles.y == 90
  
 */


