using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerSelect : MonoBehaviour
{
    public Canvas playerOne;
    public Canvas playerTwo;
    
    private GameObject playerOneChoice;
    private GameObject playerTwoChoice;

    public GameObject bowling;
    public GameObject basket;
    public GameObject pingpong;

    public Camera playerOneCamera;
    public Camera playerTwoCamera;

    public Canvas playerOneHUD;
    public Canvas playerTwoHUD;

    private Ball PlayerOne;
    private Ball PlayerTwo;

    private GameController gameController;

    private void Update()
    {
        if (!(PlayerTwo is null))
        {
            // Set the position (?), Velocity, and Accel from ball
            float p2Velocity = PlayerTwo.velocity;
            float p2Position = playerTwoCamera.transform.position.x;
            float p2Accel = PlayerTwo.regularAccel;
            if (PlayerTwo.inRough)
                p2Accel = PlayerTwo.roughAccel;
            else if (PlayerTwo.inSmooth)
                p2Accel = PlayerTwo.smoothAccel;
            Text[] Elements = playerTwoHUD.GetComponentsInChildren<Text>();
            Elements[0].text = "Position: " + p2Position;
            Elements[1].text = "Velocity: " + p2Velocity;
            Elements[2].text = "Acceleration: " + p2Accel;

            float p1Velocity = PlayerOne.velocity;
            float p1Position = playerOneCamera.transform.position.x;
            float p1Accel = PlayerOne.regularAccel;
            if (PlayerOne.inRough)
                p1Accel = PlayerOne.roughAccel;
            else if (PlayerOne.inSmooth)
                p1Accel = PlayerOne.smoothAccel;
            Text[] Elements1 = playerOneHUD.GetComponentsInChildren<Text>();
            Elements1[0].text = "Position: " + p1Position;
            Elements1[1].text = "Velocity: " + p1Velocity;
            Elements1[2].text = "Acceleration: " + p1Accel;
        }
    }

    void Start()
    {
        gameController = this.gameObject.GetComponent<GameController>();
    }

    public void BowlingballChoice(int playerNumber)
    {
        if (playerNumber == 1)
            playerOneChoice = bowling;
        else
            playerTwoChoice = bowling;
        this.HideCanvas();
    }

    public void BasketballChoice(int playerNumber)
    {
        if (playerNumber == 1)
            playerOneChoice = basket;
        else
            playerTwoChoice = basket;
        this.HideCanvas();
    }

    public void PingpongChoice(int playerNumber)
    {
        if (playerNumber == 1)
            playerOneChoice = pingpong;
        else
            playerTwoChoice = pingpong;
        this.HideCanvas();
    }

    public Ball Populate(int playerNumber, GameObject type)
    {
        Vector3 pos = new Vector3(0, 0, 0);
        GameObject obj = Instantiate(type, pos, transform.rotation);
        Ball ballScript = obj.GetComponent<Ball>();
        ballScript.startingLane = playerNumber;
        if (playerNumber == -1)
        {
            ballScript.player = 2;
            FollowBall follow = playerTwoCamera.GetComponent<FollowBall>();
            follow.target = obj.transform;
            PlayerTwo = ballScript;
        }
        else
        { 
            ballScript.player = 1;
            FollowBall follow = playerOneCamera.GetComponent<FollowBall>();
            follow.target = obj.transform;
            PlayerOne = ballScript;
        }

        return ballScript;
    }


    private void HideCanvas()
    {
        if (playerOne.isActiveAndEnabled)
        {
            playerOne.gameObject.SetActive(false);
            playerTwo.gameObject.SetActive(true);
        }
        else if (playerTwo.isActiveAndEnabled)
        {
            playerTwo.gameObject.SetActive(false);
            Ball ballOne = Populate(1, playerOneChoice);
            Ball ballTwo = Populate(-1, playerTwoChoice);

            gameController.startGame(ballOne, ballTwo);
        }
    }
}
