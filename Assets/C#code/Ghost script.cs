using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor;
using UnityEngine;

public class Ghostscript : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentSpot;
    public float speed;
    public GameOver end;

    //start function is called at the beginning and is used to declare the rigidbody compoenet and the current spot of gameObject pointB
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpot = pointB.transform;
    }

    // Update is called once per frame
    //in this update function we calculate the distance from the current spot of the gameobject to the ghost object
    //
    void Update()
    {
        UnityEngine.Vector2 point = currentSpot.position - transform.position;
        if(currentSpot == pointB.transform)
        {
            rb.velocity = new UnityEngine.Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new UnityEngine.Vector2(-speed, 0);
        }
        if(UnityEngine.Vector2.Distance(transform.position, currentSpot.position) < 1 && currentSpot == pointA.transform)
        {
            flip();
            currentSpot = pointB.transform;   
        }
        else if(UnityEngine.Vector2.Distance(transform.position, currentSpot.position) < 1 && currentSpot == pointB.transform)
        {
            flip();
            currentSpot = pointA.transform;   
        }
        
    }
    private void flip()
    {
        UnityEngine.Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
     public void OnCollisionEnter2D( Collision2D coll ) {
       GameObject collidedWith = coll.gameObject;
        if ( collidedWith.CompareTag("Player") ) {
            end.gameOver();
        }     
        
    }
} 

