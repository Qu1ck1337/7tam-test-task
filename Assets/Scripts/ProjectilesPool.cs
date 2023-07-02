using System.Collections.Generic;
using UnityEngine;

public class ProjectilesPool : MonoBehaviour
{
    #region SERIALIZED FIELDS

    public static ProjectilesPool Self;

    [SerializeField] private int projectilesCount;
    [SerializeField] private Projectile projectilePrefab;

    #endregion

    #region FIELDS

    private Queue<Projectile> projectiles = new Queue<Projectile>();

    #endregion

    #region GETTERS

    public Projectile GetProjectile()
    {
        Projectile projectile = projectiles.Dequeue();
        projectiles.Enqueue(projectile);
        return projectile;
    }

    #endregion

    #region UNITY METHODS

    private void Awake()
    {
        Self = this;

        for (int i = 0; i < projectilesCount; i++) 
        {
            Projectile projectile = Instantiate(projectilePrefab, transform).GetComponent<Projectile>();
            projectile.gameObject.SetActive(false);
            projectiles.Enqueue(projectile);
        }
    }

    #endregion
}
