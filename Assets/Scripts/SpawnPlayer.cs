using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject player;
    public Transform spawner;
    void Start()
    {
        PhotonNetwork.Instantiate(player.name, spawner.position, spawner.rotation);
    }
}
