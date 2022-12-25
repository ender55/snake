using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class ConnectToServer : MonoBehaviour
{
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
}
