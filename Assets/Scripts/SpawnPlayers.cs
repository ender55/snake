using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject firstPlayer;
    public GameObject secondPlayer;
    public Vector3Int firstSpawn, secondSpawn;

    void Start()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            PhotonNetwork.Instantiate(firstPlayer.name, firstSpawn, Quaternion.identity);
        }
        else if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            PhotonNetwork.Instantiate(secondPlayer.name, secondSpawn, Quaternion.identity);
        }
    }
}