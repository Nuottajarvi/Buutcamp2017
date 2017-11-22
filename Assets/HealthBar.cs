using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    public Image[] hearts;
    public int health;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
   	void Update () {
		for(int i = 0; i < hearts.Length; i++)
        {
            if(i >= health)
            {
                hearts[i].CrossFadeAlpha(0, 0.25f, false);
            }
            else
            {
                hearts[i].CrossFadeAlpha(1, 0.25f, false);
            }
        }
	}
}
