using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building1Script : MonoBehaviour {

     private Animator animBuilding;


    private void Start()
    {

        animBuilding = GetComponent<Animator>();
    }


    private void StartAnimation()
    {
        Debug.Log("ItWorks");
        animBuilding.SetInteger("AnimState", 2);

    }



    private void StopAnimation()
    {
        animBuilding.SetInteger("AnimState", 1);
    }

}
