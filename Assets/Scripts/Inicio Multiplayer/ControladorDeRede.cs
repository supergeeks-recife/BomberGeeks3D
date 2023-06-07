using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class ControladorDeRede : MonoBehaviourPunCallbacks
{
    public LobbyManager lobbyManager;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        lobbyManager.connectionStatusText.text = "Conectando ao servidor...";
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        lobbyManager.connectionStatusText.text = "Conectado";
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        lobbyManager.connectionStatusText.text = "Desconectado";
    }

    public override void OnJoinedLobby()
    {
        Debug.Log(PhotonNetwork.NickName + "Entrou no lobby");
    }
}
