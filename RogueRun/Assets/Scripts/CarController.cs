using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rbCar;


    float dirX, dirY, rotateAngle;
    float Speed = 15f;

    bool onHorizontalRoad;
    bool onVerticalRoad;



    void Start()
    {
        anim = GetComponent<Animator>();
        rbCar = GetComponent<Rigidbody2D>();
      
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }


    void Movement()
    {


        if (Input.GetKey(KeyCode.RightArrow))
        {
            rbCar.AddForce(transform.right * Speed);

            if(onHorizontalRoad)
            {
                
                anim.SetInteger("CarDirection", 1);
            }
        }



        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rbCar.AddForce(transform.right * -Speed);
            
            if(onHorizontalRoad)
            {
                
                anim.SetInteger("CarDirection", 5);
            }
        }



        if (Input.GetKey(KeyCode.UpArrow))
        {
            rbCar.AddForce(transform.up * Speed);
            
            if(onVerticalRoad)
            {
                
                anim.SetInteger("CarDirection", 3);
            }  
        }



        if (Input.GetKey(KeyCode.DownArrow))
        {
            rbCar.AddForce(transform.up * -Speed);
            if(onVerticalRoad)
            {
                
                anim.SetInteger("CarDirection", 7);
            } 
        }

    }


    void OnHorizontalRoad()
    {
        onHorizontalRoad = true;
    }

    void OffHorizontalRoad()
    {
        onHorizontalRoad = false;
    }

    void OnVerticalRoad()
    {
        onVerticalRoad = true;
    }

    void OffVerticalRoad()
    {
        onVerticalRoad = false;
    }



}




/*
  void Rotate()
  {
      //car right
      if (dirX == 1 && dirY == 0)
      {
          rotateAngle = 0;
          anim.speed = 1;
          anim.SetInteger("CarDirection", 1);
      }

      //car up and right
      if (dirX == 1 && dirY == 1)
      {
          rotateAngle = -45f;
          anim.speed = 1;
          anim.SetInteger("CarDirection", 2);
      }


      //car up
      if (dirX == 0 && dirY == 1)
      {
          rotateAngle = -90f;
          anim.speed = 1;
          anim.SetInteger("CarDirection", 3);
      }


      //car up and left
      if (dirX == -1 && dirY == 1)
      {
          rotateAngle = -135f;
          anim.speed = 1;
          anim.SetInteger("CarDirection", 4);
      }


      //left
      if (dirX == -1 && dirY == 0)
      {
          rotateAngle = -180f;
          anim.speed = 1;
          anim.SetInteger("CarDirection", 5);
      }

      //Down and left
      if (dirX == -1 && dirY == -1)
      {
          rotateAngle = -225f;
          anim.speed = 1;
          anim.SetInteger("CarDirection", 6);
      }

      //Down
      if (dirX == 0 && dirY == -1)
      {
          rotateAngle = -270f;
          anim.speed = 1;
          anim.SetInteger("CarDirection", 7);
      }


      //Down and right
      if (dirX == 1 && dirY == -1)
      {
          rotateAngle = -315f;
          anim.speed = 1;
          anim.SetInteger("CarDirection", 8);
      }


  }*/
