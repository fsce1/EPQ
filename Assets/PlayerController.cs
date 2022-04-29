using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5;
    public float runSpeedMultiplier = 2;
    private float moveSpeedOG = 5f;
    public Rigidbody2D RigidBody;
    Vector2 curMovement;
    private bool isJumpHeld;
    private bool isJumpDepressed;
    public float runHeldTimer = 2;
    private float runHeldTimerOG = 2;
    public bool isRunning = false;
    public bool canDash = true;
    public bool isDashing = false;
    public float dashSpeedMult = 10;
    public float dashSpeedTime = 0.1f;
    public float dashSpeedTimeOG = 0.1f;
    private Vector2 movementStored;

    // Update is called once per frame

    void Start()
    {
        moveSpeedOG = moveSpeed;
        runHeldTimerOG = runHeldTimer;
        canDash = true;
        dashSpeedTimeOG = dashSpeedTime;
    }
    void Update()
    {
        if (isDashing == true)
        {
            curMovement = movementStored;
        }
        else
        {
            curMovement.x = Input.GetAxisRaw("Horizontal");
            curMovement.y = Input.GetAxisRaw("Vertical");
        }
        isJumpHeld = Input.GetButton("Jump");
        isJumpDepressed = Input.GetButtonUp("Jump");
        //Dash
        if (canDash == true && isJumpDepressed == true)
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
        if (isJumpHeld == true)
        {
            if(runHeldTimer > 0)
            {
                runHeldTimer -= Time.deltaTime;
            }
            else
            {
                isRunning = true;
                moveSpeed *= runSpeedMultiplier;
                canDash = false;
                runHeldTimer = runHeldTimerOG;
                if (moveSpeed > moveSpeedOG * runSpeedMultiplier)
                {
                    moveSpeed = moveSpeedOG * runSpeedMultiplier;
                }
            }
        }
       
        if (isJumpDepressed == true)
        {
            moveSpeed = moveSpeedOG;
            runHeldTimer = runHeldTimerOG;
            canDash = true;
            isRunning = false;
        }

    }
    void FixedUpdate()
    {

        RigidBody.MovePosition(RigidBody.position + curMovement * moveSpeed * Time.fixedDeltaTime);


    }
}