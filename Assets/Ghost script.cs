using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor;
using UnityEditor.ProjectWindowCallback;
using UnityEngine;

public class Ghostscript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentSpot;
    public float speed;
    public GameOver end;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpot = pointB.transform;
    }

    // Update is called once per frame
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

