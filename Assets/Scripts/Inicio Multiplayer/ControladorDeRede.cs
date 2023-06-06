using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class ControladorDeRede : MonoBehaviourPunCallbacks
{
    public TMP_Text text_conection;
    public GameObject panelLogin;
    public GameObject panelLobby;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        panelLogin.SetActive(false);
        text_conection.text = "Conectando ao servidor...";
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        panelLogin.SetActive(true);
        text_conection.text = "Conectado";
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        text_conection.text = "Desconectado";
    }

    public override void OnJoinedLobby()
    {
        
    }
}
