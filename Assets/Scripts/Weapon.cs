using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : WeaponBehaviour
{
    #region SERIALIZED FIELDS

    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private float timeForShoot;

    #endregion

    #region FIELDS

    private float timeDelta;

    #endregion

    #region UNITY METHODS

    protected override void Update()
    {
        timeDelta += Time.deltaTime;
    }

    #endregion

    #region METHODS

    public override void Fire()
    {
        if (timeDelta >= timeForShoot)
        {
            timeDelta = 0;
            var projectile = Instantiate(projectilePrefab, transform);
            var scale = projectile.transform.localScale;
            projectile.transform.rotation = transform.rotation;
            projectile.transform.position = transform.position;
            projectile.transform.localPosition = new Vector3(projectile.transform.localPosition.x, projectile.transform.localPosition.y + 0.3f, projectile.transform.localPosition.z);
            projectile.transform.SetParent(null);
            projectile.transform.localScale = scale;
        }
    }

    #endregion
}
