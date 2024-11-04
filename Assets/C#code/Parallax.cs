using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class is used to control the parallax function of the backdrop of our game
//have a dynamic moving background as we move our character
public class Parallax : MonoBehaviour
{
    private float startPos;
    private float length;
    public GameObject cam;
    public float parallaxEf;

    //start function declares where the start position relative to the background
    //set length to size of background
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // function to be able to move the backgrounds while moving the character
    //once a certain distance has been reached for the background it will update its new start position 
    void FixedUpdate()
    {
        float dist = cam.transform.position.x * parallaxEf;
        float movement = cam.transform.position.x * (1-parallaxEf);
        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

        if(movement > startPos + length)
        {
            startPos += length;
        }
        
    }
}
