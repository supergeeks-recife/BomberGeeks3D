using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorDeLobby : MonoBehaviour
{
    public GameObject panelLogin;
    public GameObject panelLobby;

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
