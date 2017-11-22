using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Movement : MonoBehaviour {

    Rigidbody rb;

    public KeyCode up;
    public KeyCode down;
    public KeyCode left;
    public KeyCode right;

	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	void Update () {
        if (Input.GetKey(up)) {
            rb.AddForce(transform.up * 5);
        }

        if (Input.GetKey(down)) {
            rb.AddForce(transform.up * -5);
        }

        if (Input.GetKey(left)) {
            rb.AddTorque(transform.forward * 2f);
        }

        if (Input.GetKey(right)) {
            rb.AddTorque(-transform.forward * 2f);
        }

        if(transform.position.x > 12) {
            transform.position -= new Vector3(23, 0, 0);
        }else if(transform.position.x < -12) {
            transform.position += new Vector3(23, 0, 0);
        } else if (transform.position.y > 7) {
            transform.position -= new Vector3(0, 13, 0);
        } else if (transform.position.y < -7) {
            transform.position += new Vector3(0, 13, 0);
        }
    }
}
