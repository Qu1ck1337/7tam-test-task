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

            // we cache transform to not call it again (optimisation)
            Transform projectileTransform = projectile.transform;

            var scale = projectile.transform.localScale;
            projectileTransform.rotation = transform.rotation;
            projectileTransform.position = transform.position;

            projectileTransform.SetParent(null);

            projectileTransform.localScale = scale;

            projectile.SetProjectileParent(gameObject);

            projectile.gameObject.SetActive(true);
        }
    }

    #endregion
}
