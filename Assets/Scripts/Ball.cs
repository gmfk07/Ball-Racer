using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int lane = 0;
    public int maxLane = 3;
    public float laneDist = 0.5f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            switchLanes(1);
        if (Input.GetKeyDown(KeyCode.S))
            switchLanes(-1);
    }

    private void switchLanes(int laneAmt)
    {
        if (Mathf.Abs(lane + laneAmt) <= maxLane)
        {
            lane += laneAmt;
            gameObject.transform.position += new Vector3(0, laneAmt * laneDist, 0);
        }
    }
}
