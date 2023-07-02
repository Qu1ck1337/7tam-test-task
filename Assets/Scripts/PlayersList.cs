using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;

public class PlayersList : MonoBehaviour
{
    [SerializeField] private PlayerLine playerLinePrefab;
    [SerializeField] private RectTransform firstLine;

    private void OnEnable()
    {
        var players = GameManager.Self.GetPlayersList();
        bool isFirstLine = true;
        PlayerLine line;
        foreach (PUN2_PlayerSync player in players)
        {
            Debug.Log("Test: " + player.name);
            if (!isFirstLine)
            {
                RectTransform newLine = Instantiate(playerLinePrefab, transform).GetComponent<RectTransform>();
                newLine.position = new Vector3(firstLine.position.x, firstLine.position.y - firstLine.rect.height, firstLine.position.z);
                line = newLine.GetComponent<PlayerLine>();
                Debug.Log(line.GetComponent<RectTransform>().position);
            }
            else
            {
                isFirstLine = false;
                line = firstLine.GetComponent<PlayerLine>();
            }

            if (player.photonView.IsMine)
            {
                line.SetPlayerData(player.name, player.GetComponent<CharacterBehaviour>().GetCoins());
            }
            else
            {
                line.SetPlayerData(player.name, player.latestCoins);
            }
        }
    }
}
