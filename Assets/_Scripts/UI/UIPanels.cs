using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanels : MonoBehaviour {
    public GameObject optionsTint;                          //Store a reference to the Game Object OptionsTint 
    public GameObject pausePanel;                           //Store a reference to the Game Object PausePanel 
    public GameObject deathPanel;

    //Call this function to activate and display the Pause panel during game play
    public void ShowPausePanel()
    {
        pausePanel.SetActive(true);
        optionsTint.SetActive(true);
    }

    //Call this function to deactivate and hide the Pause panel during game play
    public void HidePausePanel()
    {
        pausePanel.SetActive(false);
        optionsTint.SetActive(false);

    }
    ////Call this function to activate and display the Death panel during game play
    public void ShowDeathPanel()
    {
        deathPanel.SetActive(true);
        optionsTint.SetActive(true);
    }

    //Call this function to deactivate and hide the Death panel during game play
    public void HideDeathPanel()
    {
        deathPanel.SetActive(false);
        optionsTint.SetActive(false);

    }
}
