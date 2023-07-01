using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinSpawner : MonoBehaviourPunCallbacks
{
    [SerializeField] private string coinPrefabName;
    [SerializeField] private float TimeToSpawn;

    private float timer;
    private GameObject currentCoin;

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
}
