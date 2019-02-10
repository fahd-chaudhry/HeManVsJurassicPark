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
        inRange = false;
        isAlive = true;
    }
    
    void Update()
    {
<<<<<<< HEAD
        if (Input.GetKeyDown(KeyCode.E)){
            //playerAttack();
=======
        if (Input.GetKeyDown("space")
        {
            playerAttack();
>>>>>>> 7e285ac56456d5d420e76afebc01af89f41a776d
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
<<<<<<< HEAD
        GetComponent<SpriteRenderer>().sprite = dieSprite;
        yield return new WaitForSeconds(5);
        GetComponent<SpriteRenderer>().sprite = blank;
=======
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
>>>>>>> 7e285ac56456d5d420e76afebc01af89f41a776d

    }
    
    /*
    void playerAttack()
    {
        RaycastHit.Physcs2D.Raycast(transform.postition, Vector2.right);
        if(hit != null && hit.collider != null && hit.collider.tag == "enemy")
        {
            GetComponent<SpriteRenderer>().sprite = attackSprite;
            Destroy(hit.collider.gameObject);
        }
    }
    */
    public void playerBeHit(int damage)
    {
        playerHealth -= damage;
<<<<<<< HEAD
        if(playerHealth == 0)
=======
        if(playerHealth <= 0)
>>>>>>> 7e285ac56456d5d420e76afebc01af89f41a776d
        {
            StartCoroutine("Die");
        }

    }
}
