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



    float dodgeForceHorizontal1 = 10f; //force being used for the dodge(on horizontal roads)
    float dodgeForceVertical1 = 12.5f; // force being used for the dodge(on horizontal roads)
    float dodgeForceHorizontal2 = 10f; //force being used for the dodge(on vertical roads)
    float dodgeForceVertical2 = 12.5f; //force being used for the dodge(on vertical roads)
    float resetLinear = 2f; //resetting the linear drag since if its 15f, the car goes too slow
    float dodgeLinear = 15f;//pumping up the linear drag so the car dodges smoothly 

    bool triggerTimer; //used for resetting the linear drag
    float resetLinearTimerValue = 0.15f; 
    float resetLinearTimer;
    
    bool triggerDodgeTimer; //used for resetting the cooldown of the dodge, since the player can spam the dodge button.
    float dodgeCooldown;
    float dodgeReady = 1f;


    bool horizontalRoadLeft;
    bool horizontalRoadRight;
    bool verticalRoadLeft;
    bool verticalRoadRight;












    void Start()
    {
        anim = GetComponent<Animator>();
        rbCar = GetComponent<Rigidbody2D>();

        resetLinearTimer = resetLinearTimerValue;
        dodgeCooldown = dodgeReady;
        triggerDodgeTimer = false;
        triggerTimer = false;

        horizontalRoadLeft = false;
        horizontalRoadRight = false;
        verticalRoadLeft = false;
        verticalRoadRight = false;



    }

    // Update is called once per frame
    void Update()
    {

        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
        movement = new Vector2(inputX, inputY);

        Movement();
        Dodge();
        TimerResets();
        
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


    void Dodge()
    {


        //dodging while on a horizontal road and a left lane
       
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (dodgeCooldown == dodgeReady)
                {

                    if (anim.GetCurrentAnimatorStateInfo(0).IsName("CarRight"))
                    {
                        rbCar.drag = dodgeLinear;
                        if(horizontalRoadLeft == true && horizontalRoadRight == false)
                        {
                            rbCar.AddForce(transform.up * dodgeForceHorizontal1, ForceMode2D.Impulse);
                            rbCar.AddForce(transform.right * dodgeForceVertical1, ForceMode2D.Impulse);
                        }

                    if (horizontalRoadRight == true && horizontalRoadLeft == false)
                        {
                            rbCar.AddForce(transform.up * -dodgeForceHorizontal1, ForceMode2D.Impulse);
                            rbCar.AddForce(transform.right * dodgeForceVertical1, ForceMode2D.Impulse);
                        }
                        
                        triggerTimer = true;
                        triggerDodgeTimer = true;
                    }

                    if (anim.GetCurrentAnimatorStateInfo(0).IsName("CarLeft"))
                    {
                        rbCar.drag = dodgeLinear;
                        if (horizontalRoadLeft == true && horizontalRoadRight == false)
                        {
                            rbCar.AddForce(transform.up * dodgeForceHorizontal1, ForceMode2D.Impulse);
                            rbCar.AddForce(transform.right * -dodgeForceVertical1, ForceMode2D.Impulse);
                        }

                    if (horizontalRoadRight == true && horizontalRoadLeft == false)
                        {
                            rbCar.AddForce(transform.up * -dodgeForceHorizontal1, ForceMode2D.Impulse);
                            rbCar.AddForce(transform.right * -dodgeForceVertical1, ForceMode2D.Impulse);
                        }
                            
                        triggerTimer = true;
                        triggerDodgeTimer = true;
                    }



                if (anim.GetCurrentAnimatorStateInfo(0).IsName("CarUp"))
                {
                    rbCar.drag = dodgeLinear;
                    if (verticalRoadLeft == true && verticalRoadRight == false)
                    {
                        rbCar.AddForce(transform.up * dodgeForceHorizontal2, ForceMode2D.Impulse);
                        rbCar.AddForce(transform.right * dodgeForceVertical2, ForceMode2D.Impulse);
                    }

                    if (verticalRoadRight == true && verticalRoadLeft == false)
                    {
                        rbCar.AddForce(transform.up * dodgeForceHorizontal2, ForceMode2D.Impulse);
                        rbCar.AddForce(transform.right * -dodgeForceVertical2, ForceMode2D.Impulse);
                    }

                    triggerTimer = true;
                    triggerDodgeTimer = true;
                }

                if (anim.GetCurrentAnimatorStateInfo(0).IsName("CarDown"))
                {
                    rbCar.drag = dodgeLinear;
                    if (verticalRoadLeft == true && verticalRoadRight == false)
                    {
                        rbCar.AddForce(transform.up * -dodgeForceHorizontal2, ForceMode2D.Impulse);
                        rbCar.AddForce(transform.right * dodgeForceVertical2, ForceMode2D.Impulse);
                    }

                    if (verticalRoadRight == true && verticalRoadLeft == false)
                    {
                        rbCar.AddForce(transform.up * -dodgeForceHorizontal2, ForceMode2D.Impulse);
                        rbCar.AddForce(transform.right * -dodgeForceVertical2, ForceMode2D.Impulse);
                    }

                    triggerTimer = true;
                    triggerDodgeTimer = true;
                }











            }
            }
        
    }




    void TimerResets()
    {
        if(triggerTimer)
        {

            resetLinearTimer -= Time.deltaTime;
            if (resetLinearTimer <= 0f )
            {
                Debug.Log("LinearTimer is 0");
                rbCar.drag = resetLinear;
                resetLinearTimer = resetLinearTimerValue;
                triggerTimer = false;

            }
            
        }

        if (triggerDodgeTimer)
        {
            dodgeCooldown -= Time.deltaTime;
            if (dodgeCooldown <= 0)
            {
                dodgeCooldown = dodgeReady;
                triggerDodgeTimer = false;
            }
        }

    }



    void OnHorizontalRoadLeft()
    {
        horizontalRoadLeft = true;
    }

    void OffHorizontalRoadLeft()
    {
        horizontalRoadLeft = false;
    }

    void OnHorizontalRoadRight()
    {
        horizontalRoadRight = true;
    }

    void OffHorizontalRoadRight()
    {
        horizontalRoadRight = false;
    }


    void OnVerticalRoadLeft()
    {
        verticalRoadLeft = true;
    }

    void OffVerticalRoadLeft()
    {
        verticalRoadLeft = false;
    }

    void OnVerticalRoadRight()
    {
        verticalRoadRight = true;
    }

    void OffVerticalRoadRight()
    {
        verticalRoadRight = false;
    }











}











