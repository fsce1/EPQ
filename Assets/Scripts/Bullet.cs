using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform Crosshair;
    void Start()
    {
        transform.up = Crosshair.position - transform.position;

    }
    void Update()
    {
        
    }
}
