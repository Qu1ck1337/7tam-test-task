using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Character : CharacterBehaviour
{
    #region SERIALIZED FIELDS

    [Header("Player Stats")]
    [SerializeField] private int health = 5;
    [SerializeField] private int maxHealth = 10;
    [SerializeField] private int coins = 0;

    #endregion

    #region FIELDS

    private Weapon weapon;

    #endregion

    #region GETTERS

    public override int GetHealth() => health;

    public override int GetMaxHealth() => maxHealth;

    public override int GetCoins() => coins;

    public override WeaponBehaviour GetWeapon() => weapon;


    #endregion

    #region UNITY METHODS

    protected override void Awake()
    {
        weapon = GetComponentInChildren<Weapon>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Coin")
        {
            coins += collision.gameObject.GetComponent<Coin>().GetCoinValue();
            Destroy(collision.gameObject);
        }
    }

    #endregion

    #region METHODS

    public override void Damage(int damage)
    {
        health -= damage;
        if (health < 0)
        {
            gameObject.SetActive(false);
        }
    }

    public override void SetHealth(int healthToSet)
    {
        health = healthToSet;
    }

    public override void SetCoins(int coinsToSet)
    {
        coins = coinsToSet;
    }


    #endregion
}
