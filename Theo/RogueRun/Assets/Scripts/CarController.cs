using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CarController : MonoBehaviour
{

    Animator anim;
    Rigidbody2D rbCar;
    [SerializeField]
    GameObject CarCollider;
    [SerializeField]
    GameObject SlowMotionTriggerObj;
    [SerializeField]
    GameObject SlowMotionTriggerFalseObj;

    public GameObject shotPrefab;

    float inputX;
    float inputY;
    private Vector2 movement;
    float Speed = 15f;
    float bulletSpeed = 20f;



    float dodgeForceHorizontal1 = 10f; //force being used for the dodge(on horizontal roads)
    float dodgeForceVertical1 = 15f; // force being used for the dodge(on horizontal roads)
    float dodgeForceHorizontal2 = 15f; //force being used for the dodge(on vertical roads)
    float dodgeForceVertical2 = 10f; //force being used for the dodge(on vertical roads)
    float resetLinear = 2f; //resetting the linear drag since if its 15f, the car goes way too slow since there is more "friction"
    float dodgeLinear = 15f;//pumping up the linear drag so the car dodges smoothly 

    bool triggerTimer; //used for resetting the linear drag
    float resetLinearTimerValue = 0.125f;
    float resetLinearTimer;

    bool triggerDodgeTimer; //used for resetting the cooldown of the dodge, since the player can spam the dodge button.
    float dodgeCooldown;
    float dodgeReady = 1f;

    //next booleans point out wether if the car is on a certain road and lane or not.
    bool horizontalRoadLeft;
    bool horizontalRoadRight;
    bool verticalRoadLeft;
    bool verticalRoadRight;

    //manipulating the camera while in slowmotion.
    [SerializeField]
    CinemachineVirtualCamera vcam; //Finding CM Vcam1;
    bool SlowMotionTrigger;
    float zoomOutSize = 6.25f; //Zoom out size which is basically the original lens' orthographic size
    float zoomInSize = 1.75f; //How much we want to zoom in
    float zoomInDiff; //Difference between zoom in size and zoom out size(the original orthographic size)
    float zoomOutDiff;
    float zoomSpeed = 15f; //without this, the zoom would be instant and wouldn't feel smooth
    float zoomInTimer; //when this timer ends, the camera zooms out
    float zoomInTimerValue = 0.7f;
    float TimeScaleTimer; //when this timer ends, the TimeScale is back to its original value (ends the slow motion)
    float TimeScaleTimerValue = 0.1f;



    bool SpawnSpikesActive; // Boolean that indicates wether or not the spikes are active. If we didnt have this, the SlowMotionTriggerObj part of the Movement() void wouldn't work and would create problems with the dodge function.


    int CarDir;


    void Start()
    {
        anim = GetComponent<Animator>();
        rbCar = GetComponent<Rigidbody2D>();
        CarDir = 1;

        


        resetLinearTimer = resetLinearTimerValue;
        dodgeCooldown = dodgeReady;
        triggerDodgeTimer = false;
        triggerTimer = false;

        horizontalRoadLeft = false;
        horizontalRoadRight = false;
        verticalRoadLeft = false;
        verticalRoadRight = false;

        SlowMotionTrigger = false;
        zoomInTimer = zoomInTimerValue;
        TimeScaleTimer = TimeScaleTimerValue;

        SpawnSpikesActive = false;
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
        SlowMotion();
        Shooting();


    }





    void Movement()
    {

        if (inputX != 0 && inputY != 0)
        {
            //up and left
            if (movement.x == -1 && movement.y == 1)
            {
                rbCar.AddForce(movement.normalized * Speed); // pushing the car in a direction, depending on user input (W,A,S,D)
                anim.SetInteger("CarDirection", 2); // changing the animation
                CarCollider.SendMessage("diagonal135"); // changing the collision box
                if (SpawnSpikesActive == true) //If the spikes in SpawnSpikes obj are active.
                {
                    SlowMotionTriggerObj.SendMessage("CarNotFacingRight"); //Informs the left trigger of the spikes in which direction the car is going. This makes the trigger either a destruction trigger or a "start the slowmotion" trigger.
                    SlowMotionTriggerFalseObj.SendMessage("CarNotFacingRight"); // Informt the right trigger of the spikes the exact same thing.
                }

                CarDir = 2;
            }

            //up and right
            if (movement.x == 1 && movement.y == 1)
            {
                rbCar.AddForce(movement.normalized * Speed);
                anim.SetInteger("CarDirection", 4);
                CarCollider.SendMessage("diagonal45");
                if (SpawnSpikesActive == true)
                {
                    SlowMotionTriggerObj.SendMessage("CarFacingRight");
                    SlowMotionTriggerFalseObj.SendMessage("CarFacingRight");
                }

                CarDir = 4;
            }

            //down and left
            if (movement.x == -1 && movement.y == -1)
            {
                rbCar.AddForce(movement.normalized * Speed);
                anim.SetInteger("CarDirection", 8);
                CarCollider.SendMessage("diagonal45");
                if (SpawnSpikesActive == true)
                {
                    SlowMotionTriggerObj.SendMessage("CarNotFacingRight");
                    SlowMotionTriggerFalseObj.SendMessage("CarNotFacingRight");
                }

                CarDir = 8;
            }

            //down and right
            if (movement.x == 1 && movement.y == -1)
            {
                rbCar.AddForce(movement.normalized * Speed);
                anim.SetInteger("CarDirection", 6);
                CarCollider.SendMessage("diagonal135");
                if (SpawnSpikesActive == true)
                {
                    SlowMotionTriggerObj.SendMessage("CarFacingRight");
                    SlowMotionTriggerFalseObj.SendMessage("CarFacingRight");
                }

                CarDir = 6;

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
                if (SpawnSpikesActive == true)
                {
                    SlowMotionTriggerObj.SendMessage("CarNotFacingRight");
                    SlowMotionTriggerFalseObj.SendMessage("CarNotFacingRight");
                }

                CarDir = 1;
            }

            //right
            if (movement.x == 1)
            {
                rbCar.AddForce(movement.normalized * Speed);
                anim.SetInteger("CarDirection", 5);
                CarCollider.SendMessage("horizontal");
                if (SpawnSpikesActive == true)
                {
                    SlowMotionTriggerObj.SendMessage("CarFacingRight");
                    SlowMotionTriggerFalseObj.SendMessage("CarFacingRight");
                }

                CarDir = 5;

            }

            //up
            if (movement.y == 1)
            {
                rbCar.AddForce(movement.normalized * Speed);
                anim.SetInteger("CarDirection", 3);
                CarCollider.SendMessage("vertical");

                CarDir = 3;
            }

            //down
            if (movement.y == -1)
            {
                rbCar.AddForce(movement.normalized * Speed);
                anim.SetInteger("CarDirection", 7);
                CarCollider.SendMessage("vertical");
                CarDir = 7;
            }
        }

    }




    void Dodge()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (dodgeCooldown == dodgeReady)
            {

                if (anim.GetCurrentAnimatorStateInfo(0).IsName("CarRight")) //checking which direction is the car facing.
                {

                    if (horizontalRoadLeft == true) //checking on which road and lane the car is on
                    {
                        rbCar.drag = dodgeLinear; //setting the linear drag to 15 so there is more "friction" between the car and the road

                        //the actual dodge
                        rbCar.AddForce(transform.up * dodgeForceHorizontal1, ForceMode2D.Impulse);
                        rbCar.AddForce(transform.right * dodgeForceVertical1, ForceMode2D.Impulse);
                    }

                    if (horizontalRoadRight == true)
                    {
                        rbCar.drag = dodgeLinear;
                        rbCar.AddForce(transform.up * -dodgeForceHorizontal1, ForceMode2D.Impulse);
                        rbCar.AddForce(transform.right * dodgeForceVertical1, ForceMode2D.Impulse);
                    }

                    triggerTimer = true; //triggers the timer which resets the linear drag
                    triggerDodgeTimer = true; //triggers the timer which resets the cooldown of the dodge/dash
                }

                if (anim.GetCurrentAnimatorStateInfo(0).IsName("CarLeft"))
                {

                    if (horizontalRoadLeft == true)
                    {
                        rbCar.drag = dodgeLinear;
                        rbCar.AddForce(transform.up * dodgeForceHorizontal1, ForceMode2D.Impulse);
                        rbCar.AddForce(transform.right * -dodgeForceVertical1, ForceMode2D.Impulse);
                    }

                    if (horizontalRoadRight == true)
                    {
                        rbCar.drag = dodgeLinear;
                        rbCar.AddForce(transform.up * -dodgeForceHorizontal1, ForceMode2D.Impulse);
                        rbCar.AddForce(transform.right * -dodgeForceVertical1, ForceMode2D.Impulse);
                    }

                    triggerTimer = true;
                    triggerDodgeTimer = true;
                }



                if (anim.GetCurrentAnimatorStateInfo(0).IsName("CarUp"))
                {

                    if (verticalRoadLeft == true)
                    {
                        rbCar.drag = dodgeLinear;
                        rbCar.AddForce(transform.up * dodgeForceHorizontal2, ForceMode2D.Impulse);
                        rbCar.AddForce(transform.right * dodgeForceVertical2, ForceMode2D.Impulse);
                    }

                    if (verticalRoadRight == true)
                    {
                        rbCar.drag = dodgeLinear;
                        rbCar.AddForce(transform.up * dodgeForceHorizontal2, ForceMode2D.Impulse);
                        rbCar.AddForce(transform.right * -dodgeForceVertical2, ForceMode2D.Impulse);
                    }

                    triggerTimer = true;
                    triggerDodgeTimer = true;
                }

                if (anim.GetCurrentAnimatorStateInfo(0).IsName("CarDown"))
                {

                    if (verticalRoadLeft == true)
                    {
                        rbCar.drag = dodgeLinear;
                        rbCar.AddForce(transform.up * -dodgeForceHorizontal2, ForceMode2D.Impulse);
                        rbCar.AddForce(transform.right * dodgeForceVertical2, ForceMode2D.Impulse);
                    }

                    if (verticalRoadRight == true)
                    {
                        rbCar.drag = dodgeLinear;
                        rbCar.AddForce(transform.up * -dodgeForceHorizontal2, ForceMode2D.Impulse);
                        rbCar.AddForce(transform.right * -dodgeForceVertical2, ForceMode2D.Impulse);
                    }

                    triggerTimer = true;
                    triggerDodgeTimer = true;
                }

            }

        }
    }




    void SlowMotion()
    {
        if (SlowMotionTrigger == true)
        {
            Time.timeScale = 0.2f; //Slowing down the time.
            Time.fixedDeltaTime = 0.02f * Time.timeScale; //Making everysingle frame smooth and not laggy/choppy, since we've lowered the timescale value.
            zoomInDiff = zoomInSize - vcam.m_Lens.OrthographicSize;
            zoomOutDiff = zoomOutSize - vcam.m_Lens.OrthographicSize;
            vcam.m_Lens.OrthographicSize += zoomInDiff * zoomSpeed * Time.deltaTime; //the actual zoom in
            zoomInTimer -= Time.deltaTime;
            if (zoomInTimer < 0)
            {
                vcam.m_Lens.OrthographicSize += zoomOutDiff * zoomSpeed * Time.deltaTime;
                TimeScaleTimer -= Time.deltaTime;
                if (TimeScaleTimer < 0)
                {
                    Time.timeScale = 1f; // setting the timescale and fixeddeltatime to default
                    Time.fixedDeltaTime = 0.02f * Time.timeScale;
                }
            }
        }

    }




    //resets the linear drag and the dodge cooldown
    void TimerResets()
    {
        //resets the linear drag and sets the triggertimer boolean to false again after 0.125 seconds.
        if (triggerTimer)
        {

            resetLinearTimer -= Time.deltaTime;
            if (resetLinearTimer <= 0f)
            {
                rbCar.drag = resetLinear;
                resetLinearTimer = resetLinearTimerValue;
                triggerTimer = false;

            }

        }

        //resets the dodge cooldown after 1 second.
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




    void SlowMotionCol() //whenever the car collides with the (invisible) collision box in front of the spikes, the slowmotiontrigger is true and the slow motion can start 
    {
        SlowMotionTrigger = true;
    }




    void SlowMotionColFalse() //whenever the car collides with the (invisible) collision box after the spikes, the slowmotiontrigger resets (is set to false) and the zoomInTimer and TimeScaleTimer are reset to their original value;(so if the player encounters other spikes in the game, the script to work)
    {
        SlowMotionTrigger = false;
        zoomInTimer = zoomInTimerValue;
        TimeScaleTimer = TimeScaleTimerValue;
    }


    void SpikesAreActive()
    {
        SpawnSpikesActive = true;
    }

    void SpikesArentActive()
    {
        SpawnSpikesActive = false;
    }


    //next 8 void functinos are for detecting the roads and lanes the car is driving on.
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



    void Shooting()
    {
        
                
        if (Input.GetKeyDown(KeyCode.Space))
        {
           GameObject shot = Instantiate(shotPrefab, rbCar.position, Quaternion.identity);
            // these are for right, left, up and down
           if(inputX != 0 && inputY != 0)
            {
                shot.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, 0);
            }
            if (CarDir == 1)
            {
                shot.GetComponent<Rigidbody2D>().velocity = new Vector2(-bulletSpeed, 0);
            }
            if (CarDir == 3)
            {
                shot.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletSpeed);
            }
            if (CarDir == 7)
            {
                shot.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -bulletSpeed);
            }



            // these are for the diagonals
            if (inputX != 0 && inputY != 0)
            {
                if (movement.x == 1 && movement.y == 1)
                {
                    shot.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, bulletSpeed);
                }
            }




                
            if (CarDir == 2)
            {
                Debug.Log("It Shoots");
                shot.GetComponent<Rigidbody2D>().velocity = new Vector2(-bulletSpeed, bulletSpeed);
            }
            if (CarDir == 6)
            {
                shot.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, -bulletSpeed);
            }
            if (CarDir == 8)
            {
                shot.GetComponent<Rigidbody2D>().velocity = new Vector2(-bulletSpeed, -bulletSpeed);
            }
        }
    }
}
 













