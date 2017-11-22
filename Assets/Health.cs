using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Health : MonoBehaviour {

    int amount;

	public void TakeDamage() {          
        amount -= 1;
    }
}
