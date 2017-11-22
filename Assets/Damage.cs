using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

    void OnTriggerEnter(Collider other) {
        other.gameObject.GetComponent<Health>().TakeDamage();
    }
}
