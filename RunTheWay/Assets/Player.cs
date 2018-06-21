using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Rigidbody2D rb;
    Vector2 pos;
    private void Start()
    {
        pos = rb.transform.position;
        rb.bodyType = RigidbodyType2D.Static;
    }


    private void respawn(){
        rb.transform.position = pos;
        rb.transform.rotation = Quaternion.identity;
        //GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Static;
    }
    void Update () {
        if(Input.GetButtonDown("Play") || Input.GetMouseButtonDown(1) ||
           (Input.touchCount == 2 && Input.GetTouch(1).phase == TouchPhase.Began) )
        {
            respawn();
            rb.bodyType = RigidbodyType2D.Dynamic;
        }

        if (rb.bodyType != RigidbodyType2D.Static && rb.transform.position.y < -20)    respawn();
	}


}
