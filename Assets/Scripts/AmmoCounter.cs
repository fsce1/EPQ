using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCounter : MonoBehaviour
{
    public Firearm fireArm;
    public TextMesh Text;
    public Transform scalingObject;
    public float maxScale;
    public float curScaleLerp;
    // Update is called once per frame

    void Update()
    {
        Text.text = fireArm.currentMagAmount.ToString();

        curScaleLerp = maxScale * fireArm.reloadTimer;
        scalingObject.localScale = new Vector2(curScaleLerp, scalingObject.localScale.y);

    }
}
