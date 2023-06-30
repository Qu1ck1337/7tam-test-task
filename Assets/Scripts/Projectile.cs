using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    #region SERIALIZED FIELDS

    [SerializeField] private float moveSpeed = 10f;

    #endregion

    #region UNITY METHODS

    private void Update()
    {
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
    }

    #endregion
}
