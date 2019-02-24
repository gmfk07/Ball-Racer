using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ramp : MonoBehaviour
{
    public float height = 2;
    //What's the normal acceleration of gravity?
    public float gravityAccel = 9.8f;

    private float theta;
    private float hypotenuse;

    //What's the top-down deceleration on this slope?
    public float slopeAccel;
    private float groundToSlopeMult;

    void Start()
    {
        float length = transform.localScale.x;
        theta = Mathf.Atan(height/length);
        hypotenuse = Mathf.Sqrt(Mathf.Pow(height, 2) + Mathf.Pow(length, 2));
        slopeAccel = gravityAccel * Mathf.Sin(theta);
        groundToSlopeMult = length / hypotenuse;
    }
}
