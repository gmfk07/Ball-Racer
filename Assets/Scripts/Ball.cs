using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int startingLane = 0;
    public int maxLane = 1;
    public float laneDist = 2f;
    public float regularAccel = 2f;
    public float roughAccel = -.3f;
    public float smoothAccel = 3f;
    public float maxVelocity = 7f;
    public float minVelocity = 1f;
    public float velocity = 0;

    private int lane = 0;
    public bool inRough = false;
    public bool inSmooth = false;

    public int player = 1;

    private bool canMove;

    private void Start()
    {
        // Change the Y transform by 2*starting lane where lanes are -1, 0 1
        Vector3 position = this.transform.position;
        Vector3 startMove = new Vector3(0, this.transform.position.y + 2 * startingLane,0);
        lane = (int) (this.transform.position.y + startingLane);
        this.transform.position = position + startMove;

        canMove = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (player == 1) 
        { 
            if (Input.GetKeyDown(KeyCode.W))
                switchLanes(1);
            if (Input.GetKeyDown(KeyCode.S))
                switchLanes(-1);
        }
        if (player == 2)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
                switchLanes(1);
            if (Input.GetKeyDown(KeyCode.DownArrow))
                switchLanes(-1);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        string othertag = collision.gameObject.tag;
        switch (othertag)
        {
            case "Rough":
                inRough = true;
                break;

            case "Smooth":
                inSmooth = true;
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        string othertag = collision.gameObject.tag;
        switch (othertag)
        {
            case "Rough":
                inRough = false;
                break;

            case "Smooth":
                inSmooth = false;
                break;
        }
    }

    void FixedUpdate()
    {
        float accel;
        if (inRough)
            accel = roughAccel;
        else if (inSmooth)
            accel = smoothAccel;
        else
            accel = regularAccel;
        if (canMove)
        {
            gameObject.transform.position += new Vector3(velocity * Time.deltaTime, 0, 0);
            velocity = Mathf.Min(maxVelocity, velocity + (accel * Time.deltaTime));
            if (velocity < minVelocity) velocity = minVelocity;
        }
    }

    private void switchLanes(int laneAmt)
    {
        if (Mathf.Abs(lane + laneAmt) <= maxLane)
        {
            lane += laneAmt;
            gameObject.transform.position += new Vector3(0, laneAmt * laneDist, 0);
        }
    }

    public void SetPlayer(int playerNumber)
    {
        player = playerNumber;
    }

    //cue for the race starting
    public void startMoving()
    {
        this.canMove = true;
    }
}
