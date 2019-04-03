using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationControl : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rbEnemy;



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rbEnemy = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if(this.transform.position.x > 0)
        {
            anim.SetInteger("enemyDir", 3);
        }
        else if(this.transform.position.x < 0)
        {
            anim.SetInteger("enemyDir", 1);
        }
        else if(this.transform.position.y > 0)
        {
            anim.SetInteger("enemyDir", 2);
        }
        else if(this.transform.position.y < 0)
        {
            anim.SetInteger("enemyDir", 4);
        }

    }
}
