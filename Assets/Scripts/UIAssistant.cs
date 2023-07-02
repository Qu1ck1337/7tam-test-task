using UnityEngine;

public class UIAssistant : MonoBehaviour
{
    public static UIAssistant Self;

    #region SERIALIZED FIELDS

    [SerializeField] private GameObject playerList;

    #endregion

    #region UNITY METHODS

    private void Awake()
    {
        Self = this;
    }

    private void Update()
    {
        if (GameManager.Self.GetIsGameFinished())
        {
            playerList.gameObject.SetActive(true);
        }
    }

    #endregion
}
