using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    #region SERIALIZED FIELDS

    [SerializeField] private int value;

    #endregion

    #region GETTERS

    public int GetCoinValue() => value; 

    #endregion
}