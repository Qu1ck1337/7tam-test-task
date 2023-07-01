using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PUN2_RoomController : MonoBehaviourPunCallbacks
{
    //Player spawn point
    [SerializeField] private List<Transform> spawnPoints = new List<Transform>();

    // Use this for initialization
    void Start()
    {
        //In case we started this demo with the wrong scene being active, simply load the menu scene
        if (PhotonNetwork.CurrentRoom == null)
        {
            Debug.Log("Is not in the room, returning back to Lobby");
            UnityEngine.SceneManagement.SceneManager.LoadScene("Lobby");
            return;
        }

        int playersCount = PhotonNetwork.PlayerList.ToList().Count();

        Debug.Log(PhotonNetwork.CurrentRoom.CustomProperties);

        //We're in a room. spawn a character for the local player. it gets synced by using PhotonNetwork.Instantiate
        PhotonNetwork.Instantiate("Player " + playersCount.ToString(), spawnPoints[playersCount - 1].position, spawnPoints[playersCount - 1].rotation, 0);
    }


    public override void OnLeftRoom()
    {
        //We have left the Room, return back to the GameLobby
        UnityEngine.SceneManagement.SceneManager.LoadScene("Lobby");
    }
}
