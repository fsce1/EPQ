using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Collider2D detectorHitbox;
    bool hasSeenPlayer;

    private void OnTriggerEnter2D(Collider2D detectorHitbox)
    {
        if (detectorHitbox.gameObject.tag == "Player")
        {
            hasSeenPlayer = true;
            Debug.Log("Detected Player!");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
