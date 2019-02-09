using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    private GameObject player;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    // Start is called before the first frame update
    void Start() {
        player = GetObject.FindGameObjectWithTag ("player");
    }

    // Update is called once per frame
    void Update() {
        
    }
}
