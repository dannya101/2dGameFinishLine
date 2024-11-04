using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//this class is used to "Activate the Bird" allowing us to code the mechanics of the bird to go across our game
public class ActivateBird : MonoBehaviour
{
    public GameObject bird;
    public GameObject wall;
    public float speed;
    public GameOver end;

    //update function to have bird move across the screen right to left
    //bird is directed to fly to the wall gameobject which is on the far left of the screen
    void Update(){
        bird.transform.position = Vector2.MoveTowards(bird.transform.position, wall.transform.position, speed);
    } 
    
    //collision function to show once Gameobject Bird collides with another object with a player tag
    //a game over screen is shown to show game is now over
    public void OnCollisionEnter2D( Collision2D coll ) {
       GameObject collidedWith = coll.gameObject;
        if ( collidedWith.CompareTag("Player") ) {
            end.gameOver();
        }     
    }
}
