using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ActivateBird : MonoBehaviour
{
    // Start is called before the first frame update
    // private bool isActive = false;
    public GameObject bird;
    public GameObject wall;
    public float speed;
    public GameOver end;
    void Update(){
        // isActive = true;
        bird.transform.position = Vector2.MoveTowards(bird.transform.position, wall.transform.position, speed);
    } 
    // Update is called once per frame
    public void OnCollisionEnter2D( Collision2D coll ) {
       GameObject collidedWith = coll.gameObject;
        if ( collidedWith.CompareTag("Player") ) {
            end.gameOver();
        }     
        
    }
}
