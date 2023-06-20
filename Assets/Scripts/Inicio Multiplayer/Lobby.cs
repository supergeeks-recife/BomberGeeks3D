using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lobby : MonoBehaviourPunCallbacks
{
    public LobbyManager lobbyManager;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);    
    }

    public void ButtonCreateRoom()
    {
        PhotonNetwork.CreateRoom(lobbyManager.createRoomName.text, new RoomOptions { MaxPlayers = 4 }, null);
    }

    public void ButtonEnterRoom()
    {
        PhotonNetwork.JoinRoom(lobbyManager.enterRoomName.text);
    }

    public override void OnJoinedRoom()
    {
        SceneManager.LoadScene("Game");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Room failed " + returnCode + " Message: " + message);
    }

    public string GetNickName()
    {
        return lobbyManager.playerNameInputField.text;
    }

}
