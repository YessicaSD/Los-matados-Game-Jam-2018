using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesScripts : MonoBehaviour {

    Vector2 vectorGravity;
    Rigidbody rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        vectorGravity = new Vector2(transform.position.x, transform.position.y);
        vectorGravity = new Vector2((vectorGravity.x / vectorGravity.magnitude), (vectorGravity.y / vectorGravity.magnitude)); 

    }
	
	// Update is called once per frame
	void Update () {
        rb.AddForce(vectorGravity.x * Time.deltaTime * 1000, vectorGravity.y * Time.deltaTime * 1000,0);
	}
}
