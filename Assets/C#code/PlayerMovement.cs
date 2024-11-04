using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed;
    public float jumpSpeed;
    public float moveInput;
    private bool onGround;
    public Transform playerPos;
    public float position;
    public LayerMask ground;
    private float airTimeCount;
    public float airTime;
    private bool inAir;
    public GameOver end;
    public static float bottomY = -72f; 
    private bool isDead = false;
    public Animator anim;
    AudioSource jumpsound;
    
    // Start is called before the first frame update
    //initialize the the rigidbody of the character 
    //also intialize the jumpsound audio
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpsound = GetComponent<AudioSource>();
    }

    // initialize the inputs of how to move the charcter left and right
    //also intitialize the jumping of the character by setting the y vector to move with inputs with the movement speed
    //also initiazlize animation of speed to satisfy the condition that the speed has to be greater than a certain value of rb.velocity.x to run the animation
    //this makes it so the animation only executes when the character moves
    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new UnityEngine.Vector2(moveInput * moveSpeed, rb.velocity.y);
        anim.SetFloat("Speed", rb.velocity.x);
    }
    void Update()
    {
        ifFell();
        onGround = Physics2D.OverlapCircle(playerPos.position, position, ground);
        if(onGround == true && Input.GetKeyDown(KeyCode.UpArrow))
        {
            inAir = true;
            airTimeCount = airTime;
            rb.velocity = UnityEngine.Vector2.up * jumpSpeed;
            anim.SetBool("Jump", true);
            jumpsound.Play();
        }
        if(Input.GetKey(KeyCode.UpArrow) && inAir == true)
        {
            if(airTimeCount > 0)
            {
                rb.velocity = UnityEngine.Vector2.up * jumpSpeed;
                airTimeCount -= Time.deltaTime;
            }
            else{
                inAir = false;
                anim.SetBool("Jump", false);
            }
        }
        if(Input.GetKeyUp(KeyCode.UpArrow))
        {
            inAir = false;
        }
   }
    public void ifFell()
    {
        if ( transform.position.y < bottomY && !isDead) {
            isDead = true;
            end.gameOver();
        } 
    }
}
