using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Health : MonoBehaviour {

    public int amount;

	public void TakeDamage() {          
        amount -= 1;
        if (amount == 0) {
            gameObject.SetActive(false);
        }
    }
}
