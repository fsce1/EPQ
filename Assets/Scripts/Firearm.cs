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
    void Start()
    {
        
    }
    void Update()
    {
        transform.up = Crosshair.position - transform.position;
        RigidBody.MovePosition(Player.transform.position);
    }

    private void OnMouseDown()
    {
    }
}