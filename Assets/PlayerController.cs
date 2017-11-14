using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject rocket;

    public GameObject InstantiateRocket() {
        Quaternion quaternion = new Quaternion();
        quaternion.eulerAngles = new Vector3(-90, 0, 0);

        return GameObject.Instantiate(rocket, new Vector3(0, 0, 0), quaternion);
    }
}
