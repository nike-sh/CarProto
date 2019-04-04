﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
    private float BulletTimer;
    private float BulletTimerValue = 0.35f;

    [SerializeField]
    GameObject BulletPrefab;







    void Start()
    {
        BulletTimer = BulletTimerValue;

        

    }


    void Update()
    {
        BulletTimer -= Time.deltaTime;

        if(BulletTimer < 0 )
        {
            Destroy(BulletPrefab);
            BulletTimer = BulletTimerValue;
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet") || collision.CompareTag("Enemy"))
        {
            Destroy(BulletPrefab);
        }

     
    }


}
