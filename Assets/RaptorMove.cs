using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// player is called  Avatar
public class RaptorMove : MonoBehaviour
{
    public Sprite[] moveSprites;
    public List<Sprite> attackForm;
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
    bool moving;
    bool alive;
    bool inRange;

    // Use this for initialization
    void Start () {
        attackForm.Add(attackSprite);
        attackForm.Add(moveSprites[0]);
        moving = true;
        alive = true;
        inRange = false;
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
            if (inRange)
            {

                beHit(5);
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
        if (updateCounter == 5 + (UPDATE_RATE / moveSpeed))
        {
            updateLevel++;
            GetComponent<SpriteRenderer>().sprite = attackForm[updateLevel%2];
            updateCounter = 0;
            return damage* updateLevel % 2;

        }
        return 0;
        
    }
    
    public void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Hi" + col.gameObject.tag);
        inRange = (col.gameObject.tag.Equals("Player"));
    }

    public void beHit(int damage)
    {
        moving = false;
        health -= damage;
        if (health < 0)
        {
            alive = false;
            StartCoroutine("Die");
            
        }
    }
    IEnumerator Die()
    {
        GetComponent<SpriteRenderer>().sprite = dieSprite;
        yield return new WaitForSeconds(3);
        GetComponent<SpriteRenderer>().sprite = blank;
    }
}
