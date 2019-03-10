using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rbCar;
    public GameObject CarCollider;

    float inputX;
    float inputY;
    private Vector2 movement;
    float Speed = 15f;


    






    void Start()
    {
        anim = GetComponent<Animator>();
        rbCar = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
        movement = new Vector2(inputX, inputY);

        Movement();

    }

    void Movement()
    {

        if (inputX != 0 && inputY != 0)
        {
            //up and left
            if (movement.x == -1 && movement.y == 1)
            {
                rbCar.AddForce(movement.normalized * Speed);
                anim.SetInteger("CarDirection", 2);
                CarCollider.SendMessage("diagonal135");
            }

            //up and right
            if (movement.x == 1 && movement.y == 1)
            {
                rbCar.AddForce(movement.normalized * Speed);
                anim.SetInteger("CarDirection", 4);
                CarCollider.SendMessage("diagonal45");
            }

            //down and left
            if (movement.x == -1 && movement.y == -1)
            {
                rbCar.AddForce(movement.normalized * Speed);
                anim.SetInteger("CarDirection", 8);
                CarCollider.SendMessage("diagonal45");
            }

            //down and right
            if (movement.x == 1 && movement.y == -1)
            {
                rbCar.AddForce(movement.normalized * Speed);
                anim.SetInteger("CarDirection", 6);
                CarCollider.SendMessage("diagonal135");
            }
        }
        else
        {
            //left
            if (movement.x == -1)
            {
                rbCar.AddForce(movement.normalized * Speed);
                anim.SetInteger("CarDirection", 1);
                CarCollider.SendMessage("horizontal");
            }

            //right
            if (movement.x == 1)
            {
                rbCar.AddForce(movement.normalized * Speed);
                anim.SetInteger("CarDirection", 5);
                CarCollider.SendMessage("horizontal");
            }

            //up
            if (movement.y == 1)
            {
                rbCar.AddForce(movement.normalized * Speed);
                anim.SetInteger("CarDirection", 3);
                CarCollider.SendMessage("vertical");
            }

            //down
            if (movement.y == -1)
            {
                rbCar.AddForce(movement.normalized * Speed);
                anim.SetInteger("CarDirection", 7);
                CarCollider.SendMessage("vertical");
            }
        }


    }
}

    



 

    



