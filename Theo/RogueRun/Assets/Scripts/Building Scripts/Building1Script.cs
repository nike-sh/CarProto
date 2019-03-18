using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building1Script : MonoBehaviour {

     Animator animBuilding1;


    void Start()
    {

        animBuilding1 = GetComponent<Animator>();
    }


    void StartAnimation()
    {
        Debug.Log("ItWorks");
        animBuilding1.SetInteger("AnimState", 2);

    }



    void StopAnimation()
    {
        animBuilding1.SetInteger("AnimState", 1);
    }

}
