using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    Animator anim;
    float Damage = 25;
    float maxhp;
    float currenthp;

    private void Start()
    {
        anim = GetComponent<Animator>();
        maxhp = 100;
        currenthp = maxhp;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            currenthp -= Damage;
        }


        if(currenthp == 75)
        {
            anim.SetInteger("DamageTaken", 1);
        }

        if(currenthp == 50)
        {
            anim.SetInteger("DamageTaken", 2);
        }

        if(currenthp == 25)
        {
            anim.SetInteger("DamageTaken", 3);
        }

        if(currenthp == 0)
        {
            anim.SetInteger("DamageTaken", 4);
        }
    }


    void SpikesDamage()
    {
        currenthp -= Damage;
    }
}
