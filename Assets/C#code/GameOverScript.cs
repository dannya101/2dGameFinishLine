using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

//this is the class that manages our game over screen to allow us to start, restart, and pause gameplay
public class GameOver : MonoBehaviour
{
    
    public GameObject gameOverUI;

    //gameOver function is called to pause the flow of game and show canvas of Gameover screen
    public void gameOver()
    {
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);
    }

    //restart function is called to reload the SampleScene and resume game
    public void restart(){
        SceneManager.LoadScene( "SampleScene" );
        Time.timeScale = 1f;
    }
    //Home function is used to go to the Home screen or Main Menu Screen
    public void Home()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
