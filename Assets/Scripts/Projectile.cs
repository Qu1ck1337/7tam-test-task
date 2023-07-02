using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    #region SERIALIZED FIELDS

    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private int damage = 1;

    #endregion

    #region FIELDS

    private GameObject parent;

    #endregion

    #region UNITY METHODS

    private void Update()
    {
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CharacterBehaviour obj = collision.gameObject.GetComponent<CharacterBehaviour>();

        if (obj == null) gameObject.SetActive(false);

        if (obj == null || obj.gameObject == parent) return;
        obj.Damage(damage);
        gameObject.SetActive(false);
    }

    #endregion

    #region METHODS

    public void SetProjectileParent(GameObject gameObject)
    {
        parent = gameObject;
    }

    #endregion
}
