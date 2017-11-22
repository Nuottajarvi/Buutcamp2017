using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    public Image[] hearts;
    public GameObject player;
    
	// Update is called once per frame
   	void Update () {
		for(int i = 0; i < hearts.Length; i++)
        {
            if(i >= player.GetComponent<Health>().amount || player == null)
            {
                hearts[i].enabled = false;
            }
            else
            {
                hearts[i].enabled = true;
            }
        }
	}
}
