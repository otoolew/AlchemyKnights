using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathOptions : MonoBehaviour {


    public void RestartLevel()
    {
        SceneManager.LoadScene("Main");
    }
    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void DoPause()
    {
        //Set time.timescale to 0, this will cause animations and physics to stop updating
        Time.timeScale = 0;
        //call the ShowPausePanel function of the ShowPanels script
    }

    public void UnPause()
    {
        // Set time.timescale to 1, this will cause animations and physics to continue updating at regular speed
        Time.timeScale = 1;
        // call the HidePausePanel function of the ShowPanels script
    }
}
