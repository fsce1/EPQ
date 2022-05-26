using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCounter : MonoBehaviour
{
    public Firearm fireArm;
    public TextMesh Text;
    public Transform scalingObject;
    public float maxScale;
    // Update is called once per frame
    void Update()
    {
        Text.text = fireArm.currentMagAmount.ToString();

        if (fireArm.isReloading == true)
        {
            scalingObject.transform.localScale = scalingObject.transform.localScale / fireArm.reloadTimer;
        }
    }
}
