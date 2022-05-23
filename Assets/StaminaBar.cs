using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaBar : MonoBehaviour
{
    public PlayerController player;
    [Header("Scale Settings")]
    public Object scalingObject;
    public float minObjScale = 0;
    public float maxObjScale = 5;
    [Header("Stamina Settings")]
    public float curStamina = 1;
    public float StaminaMax = 1;
    public float regenRate = 1;
    public float runDrainRate = 1;
    public float dashDrainRate = 1;

    // Start is called before the first frame update
    void Start()
    {
        if (player.isRunning == true) {

        }
    }

    // Update is called once per frame
    void Update()
    {

        if (player.isRunning == false && player.isDashing == false) {
            curStamina = curStamina + regenRate;
        }
        else if (player.isRunning == true){
            curStamina = curStamina - runDrainRate;
        }
        else if (player.isDashing == true)
        {
            curStamina = curStamina - dashDrainRate;
        }
        if (curStamina > 1)
        {
            curStamina = 1;
        }
    }
}
