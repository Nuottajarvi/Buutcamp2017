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

    public Dictionary<string, GameObject> connectedPlayers;

    void Awake() {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    void Start () {
        DontDestroyOnLoad(this.gameObject);
        connectedPlayers = new Dictionary<string, GameObject>();
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
                case "Move": MoveIn(values); break;
                case "Update": UpdateIn(values); break;
            }
        }
	}

    private void PlayerIn(JSONNode data) {
        // Only allow new players to connect in lobby
        if (!connectedPlayers.ContainsKey(data["id"])) {
            connectedPlayers[data["id"]] = GetComponent<PlayerController>().InstantiateRocket();         
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

    private void UpdateIn(JSONNode data) {
        GameObject rocket = connectedPlayers[data["id"]];
        float ax = data["torque"]["x"].AsFloat;
        float ay = data["torque"]["y"].AsFloat;
        float az = data["torque"]["z"].AsFloat;
        rocket.GetComponent<Rigidbody>().angularVelocity = new Vector3(ax, ay, az);

        float fx = data["force"]["x"].AsFloat;
        float fy = data["force"]["y"].AsFloat;
        float fz = data["force"]["z"].AsFloat;
        rocket.GetComponent<Rigidbody>().velocity = new Vector3(fx, fy, fz);

        float rx = data["rotation"]["x"].AsFloat;
        float ry = data["rotation"]["y"].AsFloat;
        float rz = data["rotation"]["z"].AsFloat;
        float rw = data["rotation"]["w"].AsFloat;

        rocket.transform.rotation = new Quaternion(rx, ry, rz, rw);
    }
}