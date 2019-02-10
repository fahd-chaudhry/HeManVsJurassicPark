using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// player is called  Avatar
public class RaptorMove : MonoBehaviour
{
    public static int points = 0;
    public Sprite[] moveSprites;
    public List<Sprite> attackForm;
    public Sprite dieSprite;
    public Sprite blank;
    public Sprite attackSprite;
    public int moveSpeed = 2;
    public int health=2; // is secreetly 2 hit
    public int damage = 1;
    public int scoreGain = 1;
    public bool isTarget;

    // counters
    int updateLevel = 0;
    const int UPDATE_RATE = 18;
    int updateCounter = 0;
    bool moving;
    bool alive;
    bool inRange;
    GameObject player;

    // Use this for initialization
    void Start () {
        health -= 1;
        attackForm.Add(attackSprite);
        attackForm.Add(moveSprites[0]);
        moving = true;
        alive = true;
        inRange = false;
        isTarget = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
       if(player!=null)
        {
            if (player.GetComponent<Player_Move_Prot>().isTarget == false)
            {
                moving = true;
                inRange = false;
            }
        }

        if (alive)
        {
            if (moving)
            {
                UpdateMoveSprite();
                move();
            }
            if (inRange)
            {
                if (player != null)
                {
                    int dmg = attack();
                    player.GetComponent<heman_life>().playerBeHit(dmg);
                }
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
        inRange = (col.gameObject.tag.Equals("Player"));
        if (inRange)
        {
            Debug.Log("COllides");
            Debug.Log(col.gameObject.tag);
            player = col.gameObject;
            player.GetComponent<Player_Move_Prot>().isTarget = true; 
        }
    }

    public void beHit(int damage)
    {
        moving = false;
        health -= damage;
        if (health < 0)
        {
            alive = false;
            StartCoroutine("Die");
            points++;
        }
    }

    void DinoRaycast()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(1, 0));
        
    }


    static int getPoints()
    {
        return points;
    }

    //TODO recyle this thing
    IEnumerator Die()
    {
        GetComponent<SpriteRenderer>().sprite = dieSprite;
        yield return new WaitForSeconds(3);
        GetComponent<SpriteRenderer>().sprite = blank;

    }
}
