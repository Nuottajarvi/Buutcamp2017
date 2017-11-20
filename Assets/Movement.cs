using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Movement : NetworkBehaviour {

    Rigidbody rb;
    public float speed;

	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	void Update () {
        if (!isLocalPlayer)
            return;

        if (Input.GetKey(KeyCode.W)) {
            rb.AddForce(transform.up * speed);
        }

        if (Input.GetKey(KeyCode.S)) {
            rb.AddForce(-transform.up * speed);
        }

        if (Input.GetKey(KeyCode.A)) {
            rb.AddTorque(transform.forward * speed * 0.3f);
        }

        if (Input.GetKey(KeyCode.D)) {
            rb.AddTorque(-transform.forward * speed * 0.3f);
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
