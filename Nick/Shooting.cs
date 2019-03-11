using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    //public GameObject shot;
    //private Transform playerPos;
    // void Start()
    //{
    //    playerPos = GetComponent<Transform>();
    //}
    //// Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        Instantiate(shot, playerPos.position, Quaternion.identity);
    //    }
    //}


// the horizontal velocity
float hVelocity;

// the vertical velocity
float vVelocity;

// horizontal speed multiplier
public float hSpeed = .05f;


// rigibody for character
Rigidbody2D charRB;


 public bool lookingUp = false;
 public bool lookingRight = false;
 public bool lookingDown = false;
 public bool lookingLeft = false;


public GameObject projectilePrefab;
GameObject projectileInstance;
public float posOffset;

// Use this for initialization
void Start()
{
    charRB = gameObject.GetComponent<Rigidbody2D>();
    
}

// Update is called once per frame
void Update()
{
    // calls player hor input function
    getHorizontal();
    getVertical();
    GetShoot();
    // calls function that moves character
    move();
}

void GetShoot()
{
        if (lookingUp && Input.GetKeyDown(KeyCode.Space))
        {

            Vector3 projPosition = new Vector3(gameObject.transform.position.x + posOffset, gameObject.transform.position.y, gameObject.transform.position.z);
            projectileInstance = Instantiate(projectilePrefab, projPosition, Quaternion.Euler(Vector3.left * 180)) as GameObject;
        }
        else if (lookingRight && Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 projPosition = new Vector3(gameObject.transform.position.x - posOffset, gameObject.transform.position.y, gameObject.transform.position.z);
            projectileInstance = Instantiate(projectilePrefab, projPosition, Quaternion.Euler(Vector3.up * 180f)) as GameObject;
        }
        else if (lookingDown && Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 projPosition = new Vector3(gameObject.transform.position.x - posOffset, gameObject.transform.position.y, gameObject.transform.position.z);
            projectileInstance = Instantiate(projectilePrefab, projPosition, Quaternion.Euler(Vector3.right * 180f)) as GameObject;
        }
        else if (lookingLeft && Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 projPosition = new Vector3(gameObject.transform.position.x - posOffset, gameObject.transform.position.y, gameObject.transform.position.z);
            projectileInstance = Instantiate(projectilePrefab, projPosition, Quaternion.Euler(Vector3.down * 180f)) as GameObject;
        }

    }
void getVertical()
    {
        hVelocity = Input.GetAxis("Vertical") * hSpeed * Time.deltaTime;
        print(hVelocity);
    }
void getHorizontal()
{
    hVelocity = Input.GetAxis("Horizontal") * hSpeed * Time.deltaTime;
    print(hVelocity);
}

void move()
{
    if (charRB.position 

    // changes horizontal position
    charRB.transform.position = new Vector2(charRB.transform.position.x + hVelocity, charRB.transform.position.y);

    // changes vertical velocity
    charRB.velocity += (Vector2.up * vVelocity);
}



}