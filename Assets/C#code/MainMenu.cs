using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//this class is used to create the functions for the buttons on the main menu screen, play and quit
public class MainMenu : MonoBehaviour
{
    // function used for the play button to start the game
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }
    //function used to exit the game
    public void ExitGame()
    {
        Application.Quit();
    }
}
