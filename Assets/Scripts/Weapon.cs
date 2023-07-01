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
        Fire();
    }

    #endregion

    #region METHODS

    public override void Fire()
    {
        if (timeDelta >= timeForShoot && GameManager.Self.GetIsGameStarted())
        {
            timeDelta = 0;
            Projectile projectile = ProjectilesPool.Self.GetProjectile();
            var scale = projectile.transform.localScale;
            projectile.transform.rotation = transform.rotation;
            projectile.transform.position = transform.position;
            projectile.transform.localPosition = new Vector3(projectile.transform.localPosition.x, projectile.transform.localPosition.y, projectile.transform.localPosition.z);
            projectile.transform.SetParent(null);
            projectile.transform.localScale = scale;
            projectile.SetProjectileParent(this.gameObject);
            projectile.gameObject.SetActive(true);
        }
    }

    #endregion
}
