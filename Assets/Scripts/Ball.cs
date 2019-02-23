using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int startingLane = 0;
    public int maxLane = 1;
    public float laneDist = 2f;
    public float accel = 2f;
    public float maxVelocity = 7f;
    public float velocity = 0;

    private int lane = 0;
    bool inRough = false;

    public int player = 1;

    private void Start()
    {
        // Change the Y transform by 2*starting lane where lanes are -1, 0 1
        Vector3 position = this.transform.position;
        Vector3 startMove = new Vector3(0, this.transform.position.y + 2 * startingLane,0);
        lane = (int) (this.transform.position.y + startingLane);
        this.transform.position = position + startMove;
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

    public void SetPlayer(int playerNumber)
    {
        player = playerNumber;
    }
}
