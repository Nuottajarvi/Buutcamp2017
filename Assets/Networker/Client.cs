using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using System;


public class Client : MonoBehaviour {

    private string id;
    public bool connected = false;
    public Rigidbody player;

    float time;

    UDPReceive udpReceive;
    UDPSend udpSend;

    float sendLimit;
    float sendCounter;

    void Start() {
        System.Random random = new System.Random();
        id = random.Next(1000000).ToString();
        Application.runInBackground = true;
        udpReceive = GetComponent<UDPReceive>();
        udpSend = GetComponent<UDPSend>();

        sendLimit = 0.5f;
        sendCounter = 0;

    }

    void Update() {

        sendCounter = sendCounter + Time.deltaTime;

        string[] UDPPackets = udpReceive.GetLatestUDPPackets();

        foreach (string UDPPacket in UDPPackets) {
            var values = JSON.Parse(UDPPacket);

            if (values["id"].Value == id) {
                switch (values["function"].Value) {
                    case "Confirm":
                        ConfirmIn(values);
                        break;
                    case "GameStatus":
                        GameStatusIn(values);
                        break;
                }
            }
        }

        time += Time.deltaTime;
        if (time > 1f) {
            if (!connected) {
                ConnectToServerOut();
            }
            time = 0;
        }

        if (connected) {
            UpdatePosition();
        }
    }

    public void ConnectToServerOut() {
        Debug.Log("Connecting to server");
        JSONNode data = new JSONClass();

        data["function"] = "Connect";
        data["id"] = id;

        udpSend.Send(data);
    }

    public void ConfirmIn(JSONNode data) {
        connected = true;
    }

    public void MoveOut(float x, float y) {
        JSONNode data = new JSONClass();

        data["function"] = "Move";
        data["id"] = id;
        data["x"].AsFloat = x;
        data["y"].AsFloat = y;

        udpSend.Send(data);
    }

    public void GameStatusIn(JSONNode data) {
        if (data["status"].Value == "lost") {
            //LOSE GAME
        }
    }

    private void UpdatePosition() {
        JSONNode data = new JSONClass();
        data["function"] = "Update";
        data["id"] = id;

        data["force"] = new JSONClass();
        data["force"]["x"].AsFloat = player.velocity.x;
        data["force"]["y"].AsFloat = player.velocity.y;
        data["force"]["z"].AsFloat = player.velocity.z;

        data["torque"] = new JSONClass();
        data["torque"]["x"].AsFloat = player.angularVelocity.x;
        data["torque"]["y"].AsFloat = player.angularVelocity.y;
        data["torque"]["z"].AsFloat = player.angularVelocity.z;

        data["rotation"] = new JSONClass();
        data["rotation"]["x"].AsFloat = player.rotation.x;
        data["rotation"]["y"].AsFloat = player.rotation.y;
        data["rotation"]["z"].AsFloat = player.rotation.z;
        data["rotation"]["w"].AsFloat = player.rotation.w;

        udpSend.Send(data);
    }
}