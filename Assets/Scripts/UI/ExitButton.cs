using Photon.Pun;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    #region METHODS

    public void ReturnToLobby()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LoadLevel("Lobby");
    }

    #endregion
}
