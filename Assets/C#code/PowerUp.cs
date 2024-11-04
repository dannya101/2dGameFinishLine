using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    AudioSource coin;
    public GameObject coinGold;

    //function to get the audio source from Unity
    void Start()
    {
        coin = GetComponent<AudioSource>(); 
    }

    //collision function to see when the gameObject attached to the powerup script collides with the gameobject with a player tag
    //a coin collection noise will play and the coin will disappear from the screen
    public void OnCollisionEnter2D( Collision2D coll ) {
       GameObject collidedWith = coll.gameObject;
        if ( collidedWith.CompareTag("Player") ) {
            coin.Play();
            coinGold.transform.localScale = Vector3.zero;
        }     
        
    }
}
