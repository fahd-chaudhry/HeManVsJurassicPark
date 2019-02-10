using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move_Prot : MonoBehaviour {

    public int playerSpeed = 10;
    public int playerJumpPower = 1250;
      
    private float moveX;
    private float canJump = 0f;
    
    // Use this for initialization
    void start () {

    }

    // Update is called once per frame
    void Update () {
        // Create new method called player move
        PlayerMove ();
    }

    void PlayerMove() {
        // CONTROLS
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown ("Jump") && Time.time > canJump) {
            Jump();
            canJump = Time.time + 0.78f;
        }
       
        // ANIMATIONS
        if (moveX != 0) {
            GetComponent<Animator>().SetBool ("IsRunning", true);
        }
        else {
            GetComponent<Animator>().SetBool ("IsRunning", false);
        } 
       
        // PLAYER DIRECTION
        if (moveX < 0.0f) {
            GetComponent<SpriteRenderer>().flipX = true;            
        }
        else if (moveX > 0.0f) {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        
        
        // PHYSICS
        // Enables left and right movement
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);

    }

    void Jump() {
        // Jumping Code
        GetComponent<Rigidbody2D>().AddForce (Vector2.up * playerJumpPower);

    }


}