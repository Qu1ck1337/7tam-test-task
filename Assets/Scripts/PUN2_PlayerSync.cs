using UnityEngine;
using Photon.Pun;

public class PUN2_PlayerSync : MonoBehaviourPun, IPunObservable
{
    #region SERIALIZED FIELDS

    //List of the scripts that should only be active for the local player (ex. PlayerController, MouseLook etc.)
    [SerializeField] private MonoBehaviour[] localScripts;
    //List of the GameObjects that should only be active for the local player (ex. Camera, AudioListener etc.)
    [SerializeField] private GameObject[] localObjects;

    #endregion

    #region FIELDS

    //Values that will be synced over network
    private Vector3 latestPos;
    private Quaternion latestRot;
    private CharacterBehaviour character;
    private int latestHealth;
    private int latestCoins;

    #endregion

    #region GETTERS

    public int GetLatestCoins() => latestCoins;

    #endregion

    #region UNITY METHODS
    private void Start()
    {
        if (!photonView.IsMine)
        {
            //Player is Remote, deactivate the scripts and object that should only be enabled for the local player
            for (int i = 0; i < localScripts.Length; i++)
            {
                localScripts[i].enabled = false;
            }
            for (int i = 0; i < localObjects.Length; i++)
            {
                localObjects[i].SetActive(false);
            }
        }
        character = GetComponent<CharacterBehaviour>();
        GameManager.Self.OnPlayerPrefabCreated();
    }

    void Update()
    {
        if (!photonView.IsMine)
        {

            //Update remote player (smooth this, this looks good, at the cost of some accuracy)
            transform.position = Vector3.Lerp(transform.position, latestPos, Time.deltaTime * 5);
            transform.rotation = Quaternion.Lerp(transform.rotation, latestRot, Time.deltaTime * 5);
            character.SetHealth(latestHealth);
            character.SetCoins(latestCoins);
        }
    }

    #endregion

    #region PUN METHODS

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            //We own this player: send the others our data
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
            //todo make getting data by structs
            stream.SendNext(character.GetHealth());
            stream.SendNext(character.GetCoins());
        }
        else
        {
            //Network player, receive data
            latestPos = (Vector3)stream.ReceiveNext();
            latestRot = (Quaternion)stream.ReceiveNext();
            latestHealth = (int)stream.ReceiveNext();
            latestCoins = (int)stream.ReceiveNext();
        }
    }

    #endregion
}
