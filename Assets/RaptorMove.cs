using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaptorMove : MonoBehaviour
{
    public Sprite[] moveSprites;
    public Sprite dieSprite;
    public Sprite blank;
    public Sprite attackSprite;
    public int moveSpeed = 2;
    public int health=1; // is secreetly 2 hit
    public int damage = 1;

    // counters
    int updateLevel = 0;
    const int UPDATE_RATE = 18;
    int updateCounter = 0;
    bool moving = true;
    bool alive = true;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (alive)
        {
            if (moving)
            {
                UpdateMoveSprite();
                move();
            }
            if (isInRange())
            {
                attack();
            }
        }
    }

    // these two functions move the dinosaur
    void UpdateMoveSprite()
    {
        updateCounter++;
        if (updateCounter == 5 + UPDATE_RATE / moveSpeed)
        {
            updateLevel++;
            GetComponent<SpriteRenderer>().sprite = moveSprites[updateLevel % moveSprites.Length];
            updateCounter = 0;
        }
    }
    void move()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-1 * moveSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    public int attack()
    {
        updateCounter++;
        moving = false;
        if (updateCounter == 5 + UPDATE_RATE / moveSpeed)
        {
            updateLevel++;
            GetComponent<SpriteRenderer>().sprite = attackSprite;
            updateCounter = 0;
            return damage;

        }
        return 0;
        
    }

    //TODO this
    public bool isInRange()
    {
        return false;
    }

    public void beHit(int damage)
    {
        moving = false;
        health -= damage;
        if (health < 0)
        {
            alive = false;
            GetComponent<SpriteRenderer>().sprite = dieSprite;
            System.Threading.Thread.Sleep(3000);
            GetComponent<SpriteRenderer>().sprite = blank;
        }
    }
}
