using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

//this is the class which controls our main characters movement or our blue gummy character
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

    //update function that would run oce per frame calling the ifFell function to see if the player has died
    //checking if the player was jumping or not 
    //We first use our first condition by checking if the gameObject is on the Ground in game if it is then execute commands to show player is in air
    //while we are checking if the payer is air we also activate the animation function to jump and the jump sound to all occur when player is jumping
    //we then check how long the player is in air to determine how long we want our character to e in air and if the player is still in air
    //if the character is in air we turn off the jump animation and set values to show we are not in air anymore
    //In our last condition we make sure that the up arrow key is not pressed down anymore to allow us to jump again in the future saying we are not in air anymore
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

   //this function is to allow us to check if the player has fallen through the threshold y value to see if the player has not "died" yet
   public void ifFell()
   {
       if ( transform.position.y < bottomY && !isDead) {
       isDead = true;
       end.gameOver();
       } 
    }
}
