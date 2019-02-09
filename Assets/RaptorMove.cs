using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaptorMove : MonoBehaviour
{
    public Sprite[] moveSprites;
    public Sprite dieSprite;
    public Sprite attackSprite;
    int moveSpeed = -2;
    int updateLevel = 0;
    const int UPDATE_RATE = 9;
    int updateCounter = 0;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        updateCounter++;
        if(updateCounter == UPDATE_RATE)
        {
            UpdateSprite();
            updateCounter=0;
        }
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void UpdateSprite()
    {
        updateLevel++;
        GetComponent<SpriteRenderer>().sprite = moveSprites[updateLevel%moveSprites.Length];
    }

}
