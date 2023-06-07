using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LobbyManager : MonoBehaviour
{
    [Header("--- Panels ---")]
    [SerializeField] GameObject panelLogin;
    [SerializeField] GameObject panelLobby;

    [Header("--- Login ---")]
    public TMP_InputField playerNameInputField;
    public TMP_Text connectionStatusText;

    [Header("--- Lobby ---")]
    public TMP_InputField createRoomName;
    public TMP_InputField enterRoomName;

    void Start()
    {
        panelLogin.SetActive(false);
        panelLobby.SetActive(false);
        connectionStatusText.gameObject.SetActive(true);
    }

    void Update()
    {
        
    }

    public void PanelLobbyActive()
    {
        panelLobby.SetActive(true);
        panelLogin.SetActive(false);
    }

    public void PanelLoginActive()
    {
        panelLobby.SetActive(false);
        panelLogin.SetActive(true);
    }
}
