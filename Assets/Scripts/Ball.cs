using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int maxLane = 3;
    public float laneDist = 0.5f;
    public float accel = 2f;
    public float maxVelocity = 7f;
    public float velocity = 0;

    private int lane = 0;
    bool inRough = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            switchLanes(1);
        if (Input.GetKeyDown(KeyCode.S))
            switchLanes(-1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.otherCollider.gameObject.tag == "Rough")
            inRough = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.otherCollider.gameObject.tag == "Rough")
            inRough = false;
    }

    void FixedUpdate()
    {
        gameObject.transform.position += new Vector3(velocity*Time.deltaTime, 0, 0);
        velocity = Mathf.Max(maxVelocity, velocity + accel * Time.deltaTime);
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
