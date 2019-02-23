using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This handles the overall flow of the game (starting/finishing)
 * 
 * It doesn't do anything immediately; call startGame to begin the game
 * (most likely after both players choose their balls)
 */
public class GameController : MonoBehaviour
{
    //debug variables to check if things are working from the editor; should remove later
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
}
