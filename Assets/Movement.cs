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

        if(transform.position.x > 15) {
            transform.position -= new Vector3(28, 0, 0);
        }else if(transform.position.x < -15) {
            transform.position += new Vector3(28, 0, 0);
        } else if (transform.position.y > 7) {
            transform.position -= new Vector3(0, 13, 0);
        } else if (transform.position.y < -7) {
            transform.position += new Vector3(0, 13, 0);
        }
    }
}
