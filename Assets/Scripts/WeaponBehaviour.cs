using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBehaviour : MonoBehaviour
{
    #region UNITY METHODS

    protected virtual void Awake() { }

    protected virtual void Start() { }

    protected virtual void Update() { }

    #endregion

    #region METHODS

    public abstract void Fire();

    #endregion
}
