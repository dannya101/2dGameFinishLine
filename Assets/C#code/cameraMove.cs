using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class cameraMove : MonoBehaviour
{
    public float speed = 2.0f;
    public GameObject player;
    public Camera cam;
    public GameOver end;
    private bool isDead = false;

    //function to move the camera right with the product of how much time has elapsed, how fast the camera is suppose to move, and with the vector variable of the camera
    //though there is a condition if the player gameobject is left of the view of the camera the game will end as a loss
    void Update(){
        transform.position += Vector3.right * speed * Time.deltaTime;
        Vector3 bottomLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        if(player.transform.position.x < bottomLeft.x - 3 && !isDead)
        {
            isDead = true;   
            end.gameOver();
        }

    }
}
