using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class Server : MonoBehaviour {

    static Server instance;
    public static Server Instance
    {
        get
        {
            return instance;
        }
    }

    UDPReceive udpReceive;
    UDPSend udpSend;

    public List<string> connectedPlayers;

    void Awake() {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    void Start () {
        DontDestroyOnLoad(this.gameObject);
        connectedPlayers = new List<string>();
        Application.runInBackground = true;
        udpReceive = GetComponent<UDPReceive>();
        udpSend = GetComponent<UDPSend>();
    }
	
	void Update () {
        string[] UDPPackets = udpReceive.GetLatestUDPPackets();

        foreach(string UDPPacket in UDPPackets) {
            var values = JSON.Parse(UDPPacket);
            
            switch (values["function"].Value) {
                case "Connect": PlayerIn(values); break;
                case "move": MoveIn(values); break;
            }
        }
	}

    private void PlayerIn(JSONNode data) {
        // Only allow new players to connect in lobby
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != "lobby")
            return;

        if (!connectedPlayers.Contains(data["id"]) && Application.loadedLevel != 0) {
            connectedPlayers.Add(data["id"]);
            LobbyController lc = GameObject.Find("PlayerText").GetComponent<LobbyController>();
            lc.AddPlayer(data["id"]);
        }
        ConfirmConnectionOut(data["id"]);
    }

    private void ConfirmConnectionOut(string id) {
        JSONNode data = new JSONClass();
        data["function"] = "Confirm";
        data["id"] = id;

        udpSend.Send(data);
    }

    private void MoveIn(JSONNode data) {
        GameObject cube = GameObject.Find("Cube");
        cube.transform.position += new Vector3(data["x"].AsFloat, data["y"].AsFloat, 0);
    }

    public void GameLostOut() {
        JSONNode data = new JSONClass();

        data["function"] = "GameStatus";
        data["status"] = "lost";

        udpSend.Send(data);
    }
}