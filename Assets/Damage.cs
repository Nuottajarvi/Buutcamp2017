using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Damage : NetworkBehaviour {

    void OnTriggerEnter(Collider other) {
        other.gameObject.GetComponent<Health>().TakeDamage();
    }
}
