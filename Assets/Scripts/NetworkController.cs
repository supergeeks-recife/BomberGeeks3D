using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;

public class NetworkController : MonoBehaviourPunCallbacks
{
    
    public TMP_Text textoPing;
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    void Update()
    {
        textoPing.text = "Servidor: " + PhotonNetwork.CloudRegion + " Ping: " + PhotonNetwork.GetPing();
        textoPing.color = new Color(0,0,255, 1f);
    }

    public override void OnConnected()
    {
        Debug.Log("Conectado!");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("O Mestre está na sala!");
        Debug.Log("Servidor: " + PhotonNetwork.CloudRegion + " Ping: " + PhotonNetwork.GetPing());
    }
}