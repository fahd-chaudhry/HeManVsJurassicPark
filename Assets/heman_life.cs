using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heman_life : MonoBehaviour
{
    public int health;
    public bool hasDied;
    // Start is called before the first frame update
    void Start()
    {
        hadDied = false;
    }

    void Update()
    {
        if(gameObject.transform.position.y < -7)
        {
            hasDied = true;
        }
        if(hasDied == true)
        {

        }
    }

    IEnumerator Die()
    {
        yeild return new WaitForSeconds(2);
        Debug.log("Player has died");
    }
}
