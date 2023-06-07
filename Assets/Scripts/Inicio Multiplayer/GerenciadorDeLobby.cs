using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GerenciadorDeLobby : MonoBehaviour
{
    public GameObject panelLogin;
    public GameObject panelLobby;
    public TMP_InputField playerNameInputField;
    public string playerName;
    public TMP_Text connectionStatusText;

    public void ActivePanelLogin()
    {
        panelLogin.SetActive(true);
        panelLobby.SetActive(false);
    }

    public void ActivePanelLobby()
    {
        panelLobby.SetActive(true);
        panelLogin.SetActive(false);
    }
}
