using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathOptions : MonoBehaviour {
    private UIPanels showPanels;                      //Reference to the ShowPanels script used to hide and show UI panels
    private bool isDead;                              //Boolean to check if the game is paused or not
    private StartOptions startScript;                   //Reference to the StartButton script

    //Awake is called before Start()
    void Awake()
    {
        //Get a component reference to ShowPanels attached to this object, store in showPanels variable
        showPanels = GetComponent<UIPanels>();
        //Get a component reference to StartButton attached to this object, store in startScript variable
    }
    private void Start()
    {
        showPanels.GetComponent<UIPanels>();
        showPanels.HideDeathPanel();
    }
    public void RestartGame()
    {
        showPanels.HideDeathPanel();
        SceneManager.LoadScene("Town");
    }
    public void QuitToMainMenu()
    {
        showPanels.HideDeathPanel();
        SceneManager.LoadScene("MainMenu");
    }
    public void DoDeath()
    {
        Debug.Log("Death Menu");
        showPanels.ShowDeathPanel();
    }
}
