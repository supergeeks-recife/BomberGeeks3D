using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkController : MonoBehaviourPunCallbacks
{

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    void Update()
    {
        
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