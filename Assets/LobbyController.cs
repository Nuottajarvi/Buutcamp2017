using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour {

    public GameObject lobbyPlayer;

    public void AddPlayer(string name) {
    }

    public void StartGame() {
        SceneManager.LoadScene("game");

    }
}
