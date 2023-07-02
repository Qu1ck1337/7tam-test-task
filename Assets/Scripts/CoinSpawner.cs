using Photon.Pun;
using UnityEngine;

public class CoinSpawner : MonoBehaviourPunCallbacks
{
    #region SERIALIZED FIELDS

    [SerializeField] private string coinPrefabName;
    [SerializeField] private float TimeToSpawn;

    #endregion

    #region FIELDS

    private float timer;
    private GameObject currentCoin;

    #endregion

    #region UNITY METHODS

    private void Update()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            if (timer >= TimeToSpawn)
            {
                timer = 0;
                currentCoin = PhotonNetwork.Instantiate(coinPrefabName, transform.position, Quaternion.identity);
            }

            if (currentCoin == null)
            {
                timer += Time.deltaTime;
            }
        }
    }

    #endregion
}
