using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleUI : MonoBehaviour {

    public GameObject UIPanel; //Store a reference to the Game Object MenuPanel 

    //Call this function to activate and display the main menu panel during the main menu
    private void ShowMenu()
    {
        UIPanel.SetActive(true);
    }

    //Call this function to deactivate and hide the main menu panel during the main menu
    private void HideMenu()
    {
        UIPanel.SetActive(false);
    }
    public void ClickEvent()
    {
        if (UIPanel.activeSelf)
            HideMenu();
        else
            ShowMenu();
    }
}
