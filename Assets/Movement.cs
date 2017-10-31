using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    Rigidbody rb;
    public float speed;

	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	void Update () {
        if (Input.GetKey(KeyCode.W)) {
            rb.AddForce(transform.forward * speed);
        }

        if (Input.GetKey(KeyCode.S)) {
            rb.AddForce(-transform.forward * speed);
        }

        if (Input.GetKey(KeyCode.A)) {
            rb.AddTorque(-transform.up * speed);
        }

        if (Input.GetKey(KeyCode.D)) {
            rb.AddTorque(transform.up * speed);
        }
    }
}
