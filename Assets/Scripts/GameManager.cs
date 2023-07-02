using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviourPunCallbacks
{
    public static GameManager Self;

    private List<PUN2_PlayerSync> playersList = new List<PUN2_PlayerSync>();
    private bool isGameStarted;
    private bool isGameFinished;

    public bool GetIsGameStarted() => isGameStarted;

    private void Awake()
    {
        Self = this;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!isGameStarted && playersList.Count >= 2) isGameStarted = true;

        if (isGameStarted) 
        {
            int activePlayers = 0;
            foreach (PUN2_PlayerSync player in playersList)
            {
                activePlayers += player.gameObject.activeSelf ? 1 : 0;
            }
            if (activePlayers <= 1) 
            { 
                EndGame();
            }
        }
    }

    public void OnPlayerPrefabCreated()
    {
        playersList = FindObjectsOfType<PUN2_PlayerSync>(true).ToList();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        playersList = FindObjectsOfType<PUN2_PlayerSync>(true).ToList();
    }

    private void EndGame()
    {
        isGameFinished = true;
    }

    public List<PUN2_PlayerSync> GetPlayersList() => playersList;

    public bool GetIsGameFinished() => isGameFinished;
}
