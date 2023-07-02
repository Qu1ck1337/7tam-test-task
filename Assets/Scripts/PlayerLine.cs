using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerLine : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerName;
    [SerializeField] private TextMeshProUGUI playerCoins;

    public void SetPlayerData(string name, int coins)
    {
        playerName.text = name;
        playerCoins.text = coins.ToString();
    }
}
