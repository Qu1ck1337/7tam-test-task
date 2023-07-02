using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using System.Linq;

public class GameManager : MonoBehaviourPunCallbacks
{
    public static GameManager Self;
    #region FIELDS

    private List<PUN2_PlayerSync> playersList = new List<PUN2_PlayerSync>();
    private bool isGameStarted;
    private bool isGameFinished;
    private PUN2_PlayerSync winner;

    #endregion

    #region GETTERS

    public bool GetIsGameStarted() => isGameStarted;

    public bool GetIsGameFinished() => isGameFinished;

    public PUN2_PlayerSync GetWinner() => winner;

    public List<PUN2_PlayerSync> GetPlayersList() => playersList;

    #endregion

    #region UNITY METHODS

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
                isGameFinished = true;

                foreach (PUN2_PlayerSync player in playersList)
                {
                    if (player.gameObject.activeSelf) winner = player;
                }
            }
        }
    }

    #endregion

    #region PUN METHODS

    public void OnPlayerPrefabCreated()
    {
        playersList = FindObjectsOfType<PUN2_PlayerSync>(true).ToList();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        playersList = FindObjectsOfType<PUN2_PlayerSync>(true).ToList();
    }

    #endregion
}
