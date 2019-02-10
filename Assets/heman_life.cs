using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class heman_life : MonoBehaviour
{
    public int playerLives = 3;
    public int playerHealth = 10;
    public bool isAlive;
    bool inRange;
    // Start is called before the first frame update
    static void Start()
    {
        inRange = false;
        isAlive = true;
    }
    
    static void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            playerAttack();
        }
        if (inRange)
        {
            playerBeHit();
        }

        if (gameObject.transform.position.y < -7) //below ground
        {
            playerDie();
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        player = col.gameObject;
        inRange = (col.gameObject.tag.Equals("Enemy"));
    }

    static void playerDie()
    {
        playerLives--;
        isAlive = false;
        GetComponent<SpriteRenderer>.sprite = dieSprite;
        System.Threading.Thread.Sleep(5000);
        GetComponent<SpriteRenderer>.sprite = blank;
        if(playerLives == 0)
        {
            SceneManager.LoadScene("Prototype_1"); //restart level
        }
    }

    static void playerAttack()
    {
        RaycastHD.Physcs2D.Raycast(transform.postition, Vector2.right);
        if(hit != null && hit.collider != null && hit.collider.tag == "Enemy")
        {
            GetComponent<SpriteRenderer>().sprite = attackSprite;
            Destroy(hit.collider.gameObject);
        }
    }

    static void playerBeHit(int damage)
    {
        playerHealth -= damage;
        if(playerHealth <= 0)
        {
            playerDie();
        }

    }
}
