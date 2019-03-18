using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectille : MonoBehaviour {
    private Vector2 target;
    public float speed;
    public Vector2 crosshair;
    public GameObject shot;


    // Use this for initialization
    void Start () {
        crosshair = GameObject.FindGameObjectWithTag("Crosshair").transform;
        target = new Vector2(crosshair.x, crosshair.y);

    }

    // Update is called once per frame
    void Update () {
            transform.position = Vector2.MoveTowards(transform.position, crosshair, speed * Time.deltaTime);
        if (transform.position.x == crosshair.x && transform.position.y == crosshair.y)
        {
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        Destroy(shot);
    }
}
