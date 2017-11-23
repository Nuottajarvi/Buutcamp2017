using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetTexture : MonoBehaviour {

    public GameObject rocket;
    
    // Use this for initialization
    public IEnumerator Load (string url) {
        WWW www = new WWW(url);

        yield return www;

        Renderer renderer = rocket.GetComponent<Renderer>();
        renderer.material.mainTexture = www.texture;
	}

    public void LoadTexture()
    {
        StartCoroutine(Load(GetComponent<InputField>().text));
    }
}
