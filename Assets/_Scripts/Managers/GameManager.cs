using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    PlayerController player;
    // Use this for initialization
    private void Awake()
    {
        player = GetComponent<PlayerController>();
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene("Main"); 
    }
    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
