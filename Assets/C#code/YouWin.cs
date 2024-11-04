using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouWin : MonoBehaviour
{
    //function to load the main menu screen
    public void win()
    {
        SceneManager.LoadScene(0);
    }
    //collision function so once gameObject attached to you win is collied with a player tag object
    //it will pause the game and show win screen
    public void OnCollisionEnter2D( Collision2D coll ) {
       GameObject collidedWith = coll.gameObject;
        if ( collidedWith.CompareTag("Player") ) {
            Time.timeScale = 0f;
            SceneManager.LoadScene(2);  
        }     
        
    }
}
