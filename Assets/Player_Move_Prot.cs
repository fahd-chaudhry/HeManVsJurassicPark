using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move_Prot : MonoBehaviour {

    public int playerSpeed = 10;
    public int playerJumpPower = 1250;
    private int damage = 1;
    private float moveX;
    private float canJump = 0f;
    private bool inRange = false;
    private GameObject currentEnemy;
    public bool isTarget = false;
    // Use this for initialization
    void start () {

    }

    // Update is called once per frame
    void Update () {
        Debug.Log ("GOT HERE 1st");
        if (this.GetComponent<heman_life>().isAlive == true) {
            Debug.Log ("GOT HERE");
            PlayerMove();
        }
    }

    void PlayerMove() {
        // CONTROLS
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown ("Jump") && Time.time > canJump) {
            Jump();
            canJump = Time.time + 0.78f;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            attack();
        }
       
        // ANIMATIONS
        if (moveX != 0) {
            GetComponent<Animator>().SetBool ("IsRunning", true);
        }
        else {
            GetComponent<Animator>().SetBool ("IsRunning", false);
        } 
       
        // PLAYER DIRECTION
        // player goes left
        if (moveX < 0.0f) {
            GetComponent<SpriteRenderer>().flipX = true;
            
            isTarget = false;
        }
        // player goes right
        else if (moveX > 0.0f) {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        
        
        // PHYSICS
        // Enables left and right movement
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);

    }

    
  public int attack()
  {
        // run attack animation
        
        if (inRange)
        {
            currentEnemy.GetComponent<RaptorMove>().beHit(damage);
        }

      
      return 0;

  }

      
    public void OnCollisionEnter2D(Collision2D col)
    {
        inRange = (col.gameObject.tag.Equals("enemy"));
        if (inRange)
        {
            currentEnemy = col.gameObject;
        }
    }

    void Jump() {
        // Jumping Code
        GetComponent<Rigidbody2D>().AddForce (Vector2.up * playerJumpPower);
        isTarget = false;
    }


}