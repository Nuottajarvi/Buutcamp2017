using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public GameObject laser;
    public double cooldown;
    public KeyCode shoot;
    bool laserActive;

	void Start () {
        cooldown = 1;
	}
	
	void Update () {
        if (Input.GetKey(shoot) && cooldown < 0) {
            laser.SetActive(true);
            cooldown = 1.05;
        } else if(cooldown < 1){
            laser.SetActive(false);
        }
        cooldown -= Time.deltaTime;
    }
}
