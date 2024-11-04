using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource coin;
    public GameObject coinGold;
    void Start()
    {
        coin = GetComponent<AudioSource>(); 
    }
    
    public void OnCollisionEnter2D( Collision2D coll ) {
       GameObject collidedWith = coll.gameObject;
        if ( collidedWith.CompareTag("Player") ) {
            coin.Play();
            coinGold.transform.localScale = Vector3.zero;
        }     
        
    }
}
