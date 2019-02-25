using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Holds functions related to the logic of the title screen.
/// 
/// Mostly for switching to the game scene and turning overlays on/off;
/// if you want to change any text/layout, it's probably easier to
/// do it in the editor.
/// </summary>
public class TitleController : MonoBehaviour
{
    public Button startButton;
    public Button instructionsButton;
    public Button legalButton;
    public GameObject instructionsOverlay;
    public GameObject legalOverlay;

    private const string mainGameScene = "SampleScene";
    private Button[] buttonArray;

    void Start()
    {
        buttonArray = new Button[] { startButton, instructionsButton, legalButton };

        setMainButtonActivity(true);
        instructionsOverlay.SetActive(false);
        legalOverlay.SetActive(false);
    }

    /// <summary>
    /// Starts the game by transitioning to the main scene.
    /// Does nothing if the instructions/legal panels are still up.
    /// </summary>
    public void toMainGame()
    {
        SceneManager.LoadScene(mainGameScene);
    }

    /// <summary>
    /// Brings up the instructions overlay.
    /// Does nothing if a panel is already up.
    /// </summary>
    public void showInstructions()
    {
        setMainButtonActivity(false);
        instructionsOverlay.SetActive(true);
    }

    /// <summary>
    /// Brings up the legal overlay.
    /// Does nothing if a panel is already up.
    /// </summary>
    public void showLegal()
    {
        setMainButtonActivity(false);
        legalOverlay.SetActive(true);
    }

    /// <summary>
    /// Hides the instructions overlay.
    /// </summary>
    public void hideInstructions()
    {
        instructionsOverlay.SetActive(false);
        setMainButtonActivity(true);
    }

    /// <summary>
    /// Hides the legal overlay.
    /// </summary>
    public void hideLegal()
    {
        legalOverlay.SetActive(false);
        setMainButtonActivity(true);
    }



    /// <summary>
    /// Sets whether or not the buttons on the main menu are interactable.
    /// </summary>
    /// <param name="state">Desired state for button interactability</param>
    private void setMainButtonActivity(bool state)
    {
        foreach (Button button in buttonArray)
        {
            button.interactable = state;
        }
    }
}
