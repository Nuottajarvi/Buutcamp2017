using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public GameObject laser;
    float cooldown;
    public KeyCode shoot;

	void Start () {
        cooldown = 1;
	}
	
	void Update () {
        if (Input.GetKey(shoot) && cooldown < 0) {
            laser.SetActive(true);
            cooldown = 1;
        } else {
            laser.SetActive(false);
            cooldown -= Time.deltaTime;
        }
	}
}
