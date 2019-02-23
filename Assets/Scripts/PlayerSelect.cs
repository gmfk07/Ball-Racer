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

    public void BowlingballChoice(int playerNumber)
    {
        if (playerNumber == 1)
            playerOneChoice = bowling;
        else
            playerTwoChoice = bowling;
        this.HideCanvas();
    }

    public void BasketballChoic(int playerNumber)
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

    public void Populate(int playerNumber, GameObject type)
    {
        Vector3 pos = new Vector3(0, playerNumber, 0);
        GameObject obj = Instantiate(type, pos, transform.rotation);
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
            Populate(1, playerOneChoice);
            Populate(-1, playerTwoChoice);
        }
    }
}
