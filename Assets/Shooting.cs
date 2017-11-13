using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public GameObject laser;
    public float max_cooldown;
    float cooldown;

	void Start () {
        cooldown = max_cooldown;
	}
	
	void Update () {
        if (Input.GetKey(KeyCode.Space) && cooldown < 0) {
            laser.SetActive(true);
            cooldown = max_cooldown;
        } else {
            laser.SetActive(false);
            cooldown -= Time.deltaTime;
        }
	}
}
