using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouWin : MonoBehaviour
{
    
    public void win()
    {
        SceneManager.LoadScene(0);
    }
    public void OnCollisionEnter2D( Collision2D coll ) {
       GameObject collidedWith = coll.gameObject;
        if ( collidedWith.CompareTag("Player") ) {
            Time.timeScale = 0f;
            SceneManager.LoadScene(2);  
        }     
        
    }
}
