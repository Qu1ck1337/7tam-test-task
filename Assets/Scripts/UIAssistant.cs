using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAssistant : MonoBehaviour
{
    public static UIAssistant Self;
    private bool isPlayerListShown;
    [SerializeField] private PlayersList playerList;

    private void Awake()
    {
        Self = this;
    }

    private void Update()
    {
        if (GameManager.Self.GetIsGameFinished() && !isPlayerListShown)
        {
            isPlayerListShown = true;
            playerList.gameObject.SetActive(true);
        }
    }
}
