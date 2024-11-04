using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class cameraMove : MonoBehaviour
{

    // Start is called before the first frame update
    public float speed = 2.0f;
    public GameObject player;
    public Camera cam;
    public GameOver end;
    private bool isDead = false;

  
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
