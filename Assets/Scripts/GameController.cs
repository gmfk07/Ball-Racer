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

    //debug variables to check if things are working from the editor; should remove later
    [Header("Debug")]
    public bool debugGameStarted;
    public bool debugGameFinished;
    
    void Start()
    {
        debugGameStarted = false;
        debugGameFinished = false;
    }
    
    void Update()
    {
        //update debug variables using implemented functions

        //check for game being finished
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
        throw new System.Exception("not implemented");
    }



    //// Observers

    /// <summary>
    /// Check if the game started
    /// </summary>
    /// <returns>Returns true iff startGame has been called</returns>
    public bool gameStarted()
    {
        throw new System.Exception("not implemented");
    }
    
    /// <summary>
    /// Check if the game is over
    /// </summary>
    /// <returns>Returns true iff both balls have reached the finish line</returns>
    public bool gameFinished()
    {
        throw new System.Exception("not implemented");
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
        throw new System.Exception("not implemented");
    }
}
