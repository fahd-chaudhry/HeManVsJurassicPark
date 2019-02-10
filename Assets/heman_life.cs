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
    public Sprite dieSprite;
    public Sprite blank;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 10;
        inRange = false;
        isAlive = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //playerAttack();
        }
        if (inRange)
        {

        }

        if (gameObject.transform.position.y < -7) //below ground
        {
            StartCoroutine("Die");
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        player = col.gameObject;
        inRange = (col.gameObject.tag.Equals("Enemy"));
    }


    IEnumerator Die()
    {
        GetComponent<SpriteRenderer>().sprite = dieSprite;
        yield return new WaitForSeconds(5);
        GetComponent<SpriteRenderer>().sprite = blank;

        playerLives--;
        isAlive = false;

        if (playerLives == 0)
        {
            SceneManager.LoadScene("Prototype_1"); //restart level
        }
    }


  
    public void playerBeHit(int damage)
    {
        playerHealth -= damage;
        if(playerHealth <= 0)
        {
            StartCoroutine("Die");
        }

    }
}
