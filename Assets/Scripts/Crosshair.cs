using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public Rigidbody2D RigidBody;
    void FixedUpdate()
    {
        RigidBody.MovePosition(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }
}
