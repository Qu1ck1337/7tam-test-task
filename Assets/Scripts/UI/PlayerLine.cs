using TMPro;
using UnityEngine;

public class PlayerLine : MonoBehaviour
{
    #region SERIALIZED FIELDS

    [SerializeField] private TextMeshProUGUI playerName;
    [SerializeField] private TextMeshProUGUI playerCoins;

    #endregion

    #region UNITY METHODS

    private void OnEnable()
    {
        PUN2_PlayerSync winner = GameManager.Self.GetWinner();
        playerName.text = winner.photonView.Owner.NickName;

        if (winner.photonView.IsMine)
        {
            playerCoins.text = winner.GetComponent<CharacterBehaviour>().GetCoins().ToString();
        }
        else
        {
            playerCoins.text = winner.GetLatestCoins().ToString();
        }
    }

    #endregion
}
