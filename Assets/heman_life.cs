using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class heman_life : MonoBehaviour
{
    public int health;
    public bool isAlive;
    // Start is called before the first frame update
    void Start()
    {
        hadDied = true;
    }

    void Update()
    {
        if (gameObject.transform.position.y < -7)
        {
            Die();
        }
    }

    void Die()
    {
        SceneManager.LoadScene("Prototype_1"); //restart level
    }   

    void onCollisionEnter2D (Collision2D call)
    {
        if(CollectionBase.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
    }
}
