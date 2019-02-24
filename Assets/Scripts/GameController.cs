using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * This handles the overall flow of the game (starting/finishing)
 * 
 * It doesn't do anything immediately; call startGame to begin the game
 * (most likely after both players choose their balls)
 */
public class GameController : MonoBehaviour
{
    public GameObject canvasPrefab;
    public Board gameBoard;

    private bool gameStarted;
    private bool gameFinished;

    private Ball playerOneBall;
    private Ball playerTwoBall;

    //a way to check where the balls are on the board
    private float boardStart;
    private float boardEnd;
    private float positionOne
    {
        get
        {
            return playerOneBall.transform.position.x - boardStart;
        }
    }
    private float positionTwo
    {
        get
        {
            return playerTwoBall.transform.position.x - boardStart;
        }
    }
    
    void Start()
    {
        gameStarted = false;
        gameFinished = false;

        boardStart = gameBoard.transform.position.x - (gameBoard.boardSize / 2);
        boardEnd = gameBoard.boardSize;
    }
    
    void Update()
    {
        if (gameStarted && !gameFinished)
        {
            //check if game is over
            if (positionOne > boardEnd && positionTwo > boardEnd)
            {
                gameFinished = true;
            }
            //TODO: more elaborate thing to check who won
        }
    }

    //// Public Methods
    
    /// <summary>
    /// Initiate the game; initializes some things and then starts the countdown.
    /// 
    /// (currently not much to initialize I think; may be a good place to set up hazards?)
    /// </summary>
    /// <param name="playerOne">The ball object controlled by player 1</param>
    /// <param name="playerTwo">The ball object controlled by player 2</param>
    public void startGame(Ball playerOne, Ball playerTwo)
    {
        this.playerOneBall = playerOne;
        this.playerTwoBall = playerTwo;

        gameStarted = true;

        //start the countdown, which will have the balls start moving when it's done
        IEnumerator countdownRoutine = doCountdown();
        StartCoroutine(countdownRoutine);
    }



    //// Observers

    /// <summary>
    /// Check if the game started
    /// </summary>
    /// <returns>Returns true iff startGame has been called</returns>
    public bool isGameStarted()
    {
        return gameStarted;
    }
    
    /// <summary>
    /// Check if the game is over
    /// </summary>
    /// <returns>Returns true iff both balls have reached the finish line</returns>
    public bool isGameFinished()
    {
        return gameFinished;
    }



    //// Private Methods
    
    /// <summary>
    /// Performs the countdown for the start of a race.
    /// 
    /// Returning an IEnumerator allows this to run in parallel with other things, so that
    /// the second-long waiting between counts doesn't mess anything else up.
    /// </summary>
    /// <returns>whatever IEnumerators do to yield things</returns>
    private IEnumerator doCountdown()
    {
        var countdownCanvas = Instantiate(this.canvasPrefab, this.transform) as GameObject;
        Text countdownText = countdownCanvas.GetComponentInChildren<Text>();

        //do the countdown, yielding for a second between counts;
        for (int i = 3; i > 0; i --)
        {
            countdownText.text = i.ToString();
            yield return new WaitForSeconds(1);
        }

        //Start the race, then wait for a second before removing canvas
        countdownText.text = "Go!";
        startRace();
        yield return new WaitForSeconds(1);

        Destroy(countdownCanvas);
    }

    /// <summary>
    /// Cues the balls to begin moving.
    /// </summary>
    private void startRace()
    {
        playerOneBall.startMoving();
        playerTwoBall.startMoving();
    }
}
