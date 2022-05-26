using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5;
    public float runSpeedMultiplier = 2;
    float moveSpeedOG = 5f;
    public Rigidbody2D RigidBody;
    Vector2 curMovement;
    bool isJumpHeld;
    bool isJumpDepressed;
    public float runHeldTimer = 2;
    float runHeldTimerOG = 2;
    public bool isRunning = false;
    public bool canRunOrDash = true;
    public bool isDashing = false;
    public float dashSpeedMult = 10;
    public float dashSpeedTime = 0.1f;
    float dashSpeedTimeOG = 0.1f;
    Vector2 movementStored;
    public float frictionAmount;
    public float frictionAmountDashing;
    private float frictionAmountOG;
    private Vector2 curRbMovement;

    // Update is called once per frame

    void Start()
    {
        frictionAmountOG = frictionAmount;
        moveSpeedOG = moveSpeed;
        runHeldTimerOG = runHeldTimer;
        dashSpeedTimeOG = dashSpeedTime;
    }
    void Update()
    {
        if (isDashing == true)
        {
            curMovement = movementStored;
            frictionAmount = frictionAmountDashing;

        }
        else
        {
            curMovement.x = Input.GetAxisRaw("Horizontal");
            curMovement.y = Input.GetAxisRaw("Vertical");
            frictionAmount = frictionAmountOG;

        }
        isJumpHeld = Input.GetButton("Jump");
        isJumpDepressed = Input.GetButtonUp("Jump");
        //Dash
        if (isRunning == false && isJumpDepressed == true && canRunOrDash == true && (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0))
        {
            isDashing = true;
            movementStored = curMovement;
        }

        if (isDashing == true)
        {
            if (dashSpeedTime > 0)
            {
                moveSpeed *= dashSpeedMult;
                if (moveSpeed > moveSpeedOG * dashSpeedMult)
                {
                    moveSpeed = moveSpeedOG * dashSpeedMult;
                }
                dashSpeedTime -= Time.deltaTime;
            }
            else
            {
                moveSpeed = moveSpeedOG;
                isDashing = false;
                dashSpeedTime = dashSpeedTimeOG;
            }


        }
        //Run
        if (isJumpHeld == true && canRunOrDash == true)
        {
            if(runHeldTimer > 0)
            {
                runHeldTimer -= Time.deltaTime;
            }
            else if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                isRunning = true;
                moveSpeed *= runSpeedMultiplier;
                runHeldTimer = runHeldTimerOG;
                if (moveSpeed > moveSpeedOG * runSpeedMultiplier)
                {
                    moveSpeed = moveSpeedOG * runSpeedMultiplier;
                }
            }
            else
            {
                isRunning = false;
            }
        }
       
        if (isJumpDepressed == true|| canRunOrDash == false)
        {
            moveSpeed = moveSpeedOG;
            runHeldTimer = runHeldTimerOG;
            isRunning = false;
        }

    }


    void FixedUpdate()
    {
        curRbMovement.x = RigidBody.velocity.x;
        curRbMovement.y = RigidBody.velocity.y;
        RigidBody.AddForce(curMovement * moveSpeed * frictionAmount);
        RigidBody.AddForce(-curRbMovement * frictionAmount);
    }
}