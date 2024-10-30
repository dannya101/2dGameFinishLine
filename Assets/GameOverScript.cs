using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameOverUI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void gameOver()
    {
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);
    }
    public void restart(){
        
        SceneManager.LoadScene( "SampleScene" );
        Time.timeScale = 1f;
    }
    public void Home()
    {
        SceneManager.LoadScene("Main Menu");
    }
}