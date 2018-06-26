using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    [Header("Varibles")]
    Rigidbody rb;
    public float sideSpeed;
    public float forwardSpeed;
    public float gravity;

	// Use this for initialization
	void Start () {
		rb= GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //rb.AddForce(0, 0, forwardSpeed * Time.deltaTime);
        //rb.AddForce(0, -1, 0);
        rb.AddRelativeForce(Vector3.down * gravity);
        if (Input.GetKey("d"))
        {
            rb.AddForce(sideSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            transform.Rotate(Vector3.forward * Time.deltaTime * 100);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sideSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            transform.Rotate(Vector3.forward * Time.deltaTime * 100);
        }
        if (Input.GetKey("w"))
        {
            rb.AddForce(0, 0, forwardSpeed * Time.deltaTime);
           
        }
    }
}
