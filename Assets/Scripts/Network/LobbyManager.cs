using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LobbyManager : MonoBehaviour
{
    [SerializeField] GameObject panelLogin;
    [SerializeField] GameObject panelLobby;

    public TMP_Text lobbyStartTime;
    public TMP_InputField playerNameInputField;
    public string playerName;
    public TMP_Text connectionStatusText;
    void Start()
    {
        lobbyStartTime.gameObject.SetActive(false); 
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
