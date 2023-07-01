using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterStatsBar : MonoBehaviour
{
    #region FIELDS

    private Character playerCharacter;
    private TextMeshPro coinCounter;

    #endregion

    #region UNITY METHODS

    private void Start()
    {
        playerCharacter = GetComponentInParent<Character>();
        coinCounter = GetComponentInChildren<TextMeshPro>();
    }

    private void Update()
    {
        coinCounter.text = playerCharacter.GetCoins().ToString();
    }

    #endregion
}
