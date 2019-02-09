using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeManMove : MonoBehaviour {

    public int playerSpeed = 2;
    public bool facingRight = true;
    public int playerJumpPower = 1250;
    public float moveX;

    // Update is called once per frame
    void Update()
    {
        playerMove();

    }

    void playerMove()
    {
        //controls
        moveX = Input.GetAxis("Horizantal");
        //animations

        //player direction
        if (moveX < 0.0f && facingRight == false)
        {
            flipPlayer();
        }
        else if (moveX > 0.0f && facingRight == true)
        {
            flipPlayer();
        }

        //phyiscs
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);

    }

    void playerJump()
    {
        //jump controls
    }

    void flipPlayer()
    {

    }
   
}
