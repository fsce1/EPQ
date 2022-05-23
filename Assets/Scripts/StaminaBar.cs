using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaBar : MonoBehaviour
{
    public PlayerController player;
    [Header("Scale Settings")]
    public Transform scalingObject;
    public float maxObjScale = 5;
    public float curScaleLerp = 1;
    public SpriteRenderer tintingObject;
    public Color maxColour;
    public Color lockedColour;
    [Header("Stamina Settings")]
    public float curStamina = 1;
    public float staminaMax = 1;
    public float regenRate = 1;
    public float runDrainRate = 1;
    public float dashDrainRate = 1;

    // Start is called before the first frame update
    void Update()
    {
        if (curStamina > staminaMax)
        {
            curStamina = staminaMax;
            player.canRunOrDash = true;
            tintingObject.color = maxColour;
        }
        if (curStamina <= 0)
        {
            curStamina = 0;
            player.canRunOrDash = false;
            tintingObject.color = lockedColour;

        }


        curScaleLerp = maxObjScale * curStamina;
        scalingObject.localScale = new Vector2(curScaleLerp, scalingObject.localScale.y);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (player.isRunning == false && player.isDashing == false)
        {
            curStamina = curStamina + regenRate;
        }
        else if (player.isRunning == true && (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0))
        {
            curStamina = curStamina - runDrainRate;
        }
        else if (player.isDashing == true && (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0))
        {
            curStamina = curStamina - dashDrainRate;
        }
    }
}
