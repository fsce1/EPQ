using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D RigidBody;
    public float bulletInitialSpeed;
    void Start()
    {
        RigidBody.AddRelativeForce(new Vector2(0, bulletInitialSpeed));

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Object.Destroy(this);
    }
    void Update()
    {
        
    }
}
