using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform Crosshair;
    public Rigidbody2D RigidBody;
    public float bulletInitialSpeed;
    public bool isTracking;
    public Transform objectToTrack;


    void Start()
    {
        //transform.up = Crosshair.position - transform.position;
        transform.LookAt(Crosshair);
        RigidBody.AddRelativeForce(new Vector2(0, bulletInitialSpeed));

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
    void Update()
    {
<<<<<<< HEAD
        if (isTracking == true)
        {
            DoTrack();
        }

        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(gameObject);
        }
=======
        
>>>>>>> parent of 9eb1288 (Further work on ammo counter)
    }
    private void DoTrack()
    {

    }

}
