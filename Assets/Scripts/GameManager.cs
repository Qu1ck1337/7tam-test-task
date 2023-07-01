using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviourPunCallbacks
{
    public static GameManager Self;

    private List<GameObject> characterBehaviours = new List<GameObject>();
    private bool isGameStarted;

    public bool GetIsGameStarted() => isGameStarted;

    private void Awake()
    {
        Self = this;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!isGameStarted && PhotonNetwork.PlayerList.Length >= 2) isGameStarted = true;

    }
}
