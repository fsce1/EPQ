using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Firearm : MonoBehaviour
{
    [Header("Position Settings")]
    public Transform Crosshair;
    public Transform Player;
    public Rigidbody2D RigidBody;
    [Header("Firing Settings")]
    public GameObject objToDuplicate;
    public Transform muzzlePoint;
    [Header("Reload Settings")]
    public int currentMagAmount;
    public int magCapacity;
    public float reloadTimer;
    public float reloadTimerOG;
    public bool canFire = true;
    public bool isReloading;

    void Start()
    {
        reloadTimerOG = reloadTimer;
    }
    void Update()
    {
        transform.up = Crosshair.position - transform.position;
        RigidBody.MovePosition(Player.transform.position);

        if (currentMagAmount >= magCapacity)
        {
            currentMagAmount = magCapacity;
            isReloading = false;
        }

        if (currentMagAmount < 1)
        {
            canFire = false;
        }
        else
        {
            canFire = true;
        }

        if (Input.GetButtonDown("Reload"))
        {
            isReloading = true;
        }

        if (isReloading == true)
        {
            if (reloadTimer < 0)
            {
                currentMagAmount += 1;
                reloadTimer = reloadTimerOG;
            }
            if (Input.GetMouseButtonDown(0))
            {
                isReloading = false;
                canFire = true;
                reloadTimer = reloadTimerOG;
            }
            canFire = false;
            reloadTimer -= Time.deltaTime;


        }

        if (Input.GetMouseButtonDown(0) && canFire == true)
        {
            Instantiate(objToDuplicate, muzzlePoint.position, this.transform.rotation);
            currentMagAmount -= 1;
        }
    }
}