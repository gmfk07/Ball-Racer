using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This holds some useful data for the board, mostly related to its size
 * 
 * May be useful for placing terrain later
 */
public class Board : MonoBehaviour
{
    public int boardSize = 100;

    void Start()
    {
        //scale board to defined size
        Vector3 originalScale = transform.localScale;
        transform.localScale = new Vector3(boardSize, originalScale.y, originalScale.z);
    }
}
