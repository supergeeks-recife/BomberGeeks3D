using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;
using Photon.Pun.UtilityScripts;

using Hashtable = ExitGames.Client.Photon.Hashtable;

public class NetworkController : MonoBehaviourPunCallbacks
{
    [SerializeField] LobbyManager lobbySystem;
    [SerializeField] byte playerRoomMax = 5;

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
        lobbySystem.PanelLobbyActive();

        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Entrei no Lobby");
        PhotonNetwork.JoinRandomRoom();
    }


    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Falhou ao entrar no lobby, vou tentar de novo");
        string roomName = "Room" + Random.Range(1000, 10000);

           //Propriedades da sala
           RoomOptions roomOptions = new RoomOptions()
           {
               IsOpen = true,
               IsVisible = true,
               MaxPlayers = playerRoomMax
           };

           PhotonNetwork.CreateRoom(roomName, roomOptions, TypedLobby.Default);
           Debug.Log(roomName);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Entrou na sala");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("O player Entrou na sala");

        //Verificar se a sala já está cheia
        if (PhotonNetwork.CurrentRoom.PlayerCount == playerRoomMax)
        {
            foreach (var player in PhotonNetwork.PlayerList)
            {
                //O Master Client será o responsável por carregar a cena de jogo
                if (player.IsMasterClient)
                {
                    StartGame();// -> OLHA AQUI TIO!!!
                    //Chama o Countdown
                    Hashtable props = new Hashtable
                    {
                        {CountdownTimer.CountdownStartTime, (float) PhotonNetwork.Time}
                    };

                    PhotonNetwork.CurrentRoom.SetCustomProperties(props);
                }
            }
        }
    }

    public override void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged)
    {
        if (propertiesThatChanged.ContainsKey(CountdownTimer.CountdownStartTime))
        {
            //Aparecer contador para todos os players quandos as propriedades da sala forem atualizadas
            lobbySystem.lobbyStartTime.gameObject.SetActive(true);
        }
    }

    void StartGame()
    {
        PhotonNetwork.LoadLevel("Game");
    }

    
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Desconectado: " + cause.ToString());
        lobbySystem.PanelLoginActive();
    }

    public void CancelMatch()//Botão CANCEL
    {
        PhotonNetwork.Disconnect(); //print: DisconnectByClientLogic

        lobbySystem.connectionStatusText.gameObject.SetActive(false);
    }

    public void SearchMatch()//Botão READY
    {
        PhotonNetwork.NickName = lobbySystem.playerNameInputField.text;

        lobbySystem.connectionStatusText.gameObject.SetActive(true);

        PhotonNetwork.ConnectUsingSettings();
    }
}