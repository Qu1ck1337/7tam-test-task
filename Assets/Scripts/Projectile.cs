using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    #region SERIALIZED FIELDS

    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private int damage = 1;

    #endregion

    #region UNITY METHODS

    private void Update()
    {
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CharacterBehaviour obj = collision.gameObject.GetComponent<CharacterBehaviour>();
        if (obj == null) return;
        obj.Damage(damage);
        Destroy(this.gameObject);
    }

    #endregion
}
