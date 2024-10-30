using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    // Start is called before the first frame update
    private float startPos;
    private float length;
    public GameObject cam;

    public float parallaxEf;
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float dist = cam.transform.position.x * parallaxEf;
        float movement = cam.transform.position.x * (1-parallaxEf);
        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

        if(movement > startPos + length)
        {
            startPos += length;
        }
        else if(movement < startPos - length)
        {
            startPos -= length;
        }
        
    }
}
