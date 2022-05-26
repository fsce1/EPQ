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
    Func<bool> reloadFuncPointer;
    bool blank() => true;

    void Start()
    {
        reloadTimerOG = reloadTimer;
        reloadFuncPointer = blank;
    }
    void Update()
    {
        transform.up = Crosshair.position - transform.position;
        RigidBody.MovePosition(Player.transform.position);

        //if (currentMagAmount >= magCapacity)
        //{
        //    currentMagAmount = magCapacity;
        //    IsReloading = false;
        //}

        if (currentMagAmount < 1)
        {
            reloadFuncPointer = DoReload;
            canFire = false;
        }
        else
        {
            canFire = true;
        }

        if (Input.GetButtonDown("Reload"))
        {
            //DoReload();
            reloadFuncPointer = DoReload;
        }

        reloadFuncPointer();

        if (Input.GetMouseButtonDown(0) && canFire)
        {
            Instantiate(objToDuplicate, muzzlePoint.position, this.transform.rotation);
            currentMagAmount -= 1;
        }
    }

    private bool DoReload()
    {
        if (currentMagAmount < magCapacity)
        {
            if (reloadTimer < 0)
            {
                currentMagAmount += 1;
                reloadTimer = reloadTimerOG;
            }
            if (Input.GetMouseButtonDown(0))
            {
                canFire = true;
                reloadTimer = reloadTimerOG;
            }
            canFire = false;
            reloadTimer -= Time.deltaTime;
            return true;
        }
        reloadFuncPointer = blank;
        return false;
    }
}