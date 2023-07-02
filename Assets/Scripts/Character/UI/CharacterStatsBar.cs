using TMPro;
using UnityEngine;

public class CharacterStatsBar : MonoBehaviour
{
    #region FIELDS

    private Character playerCharacter;
    private TextMeshProUGUI coinCounter;

    #endregion

    #region UNITY METHODS

    private void Start()
    {
        playerCharacter = GetComponentInParent<Character>();
        coinCounter = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        coinCounter.text = playerCharacter.GetCoins().ToString();
    }

    #endregion
}
