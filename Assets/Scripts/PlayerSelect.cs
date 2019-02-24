using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private GameController gameController;

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
            ballScript.player = 2;
        else
        { 
            ballScript.player = 1;
            FollowBall follow = playerOneCamera.GetComponent<FollowBall>();
            follow.target = obj.transform;
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
