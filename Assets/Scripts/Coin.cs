using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Coin : MonoBehaviour
{
    #region SERIALIZED FIELDS

    [SerializeField] private int value;

    #endregion

    #region GETTERS

    public int GetCoinValue() => value;

    #endregion

    #region UNITY METHODS

    private void Awake()
    {
        gameObject.tag = "Coin";
    }

    #endregion
}
