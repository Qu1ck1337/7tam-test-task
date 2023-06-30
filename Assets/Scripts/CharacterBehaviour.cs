using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class CharacterBehaviour : MonoBehaviour
{
    #region GETTERS

    /// <summary>
    /// Health
    /// </summary>
    /// <returns>player's health</returns>
    public abstract int GetHealth();

    /// <summary>
    /// Coins
    /// </summary>
    /// <returns>player's coins</returns>
    public abstract int GetCoins();

    /// <summary>
    /// Player's movement input
    /// </summary>
    public abstract Vector2 GetInputMovement();

    /// <summary>
    /// Is Player jumping
    /// </summary>
    /// <returns>true if jump button was pressed</returns>
    public abstract bool IsJumping();

    /// <summary>
    /// Returns playes's weapon
    /// </summary>
    /// <returns></returns>
    public abstract WeaponBehaviour GetWeapon();

    #endregion

    #region UNITY METHODS

    /// <summary>
    /// Awake.
    /// </summary>
    protected virtual void Awake() { }

    /// <summary>
    /// Start.
    /// </summary>
    protected virtual void Start() { }

    /// <summary>
    /// Update.
    /// </summary>
    protected virtual void Update() { }

    /// <summary>
    /// Late Update.
    /// </summary>
    protected virtual void LateUpdate() { }

    #endregion
}