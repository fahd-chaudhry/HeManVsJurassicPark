using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaptorMove : MonoBehaviour {

    int moveSpeed = 15;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
	}
}
