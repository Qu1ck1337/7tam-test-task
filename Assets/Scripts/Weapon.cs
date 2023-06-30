using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : WeaponBehaviour
{
    #region SERIALIZED METHODS

    [SerializeField] private Projectile projectilePrefab;

    #endregion

    #region UNITY METHODS

    #endregion

    #region METHODS

    public override void Fire()
    {
        var projectile = Instantiate(projectilePrefab, transform);
        var scale = projectile.transform.localScale;
        projectile.transform.rotation = transform.rotation;
        projectile.transform.position = transform.position;
        projectile.transform.localPosition = new Vector3(projectile.transform.localPosition.x, projectile.transform.localPosition.y + 0.3f, projectile.transform.localPosition.z);
        projectile.transform.SetParent(null);
        projectile.transform.localScale = scale;
    }

    #endregion
}
