using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    private CharacterInput input;
    private Vector2 movement;
    private bool isJumping;
    private Weapon weapon;

    #endregion

    #region GETTERS

    public override int GetHealth() => health;

    public override int GetMaxHealth() => maxHealth;

    public override int GetCoins() => coins;

    public override Structs.CharacterData GetCharacterData()
    {
        Structs.CharacterData data = new Structs.CharacterData()
        {
            health = health,
            coins = coins,
        };
        return data;
    }

    public override Vector2 GetInputMovement() => movement;

    public override bool IsJumping()
    {
        if (isJumping == false) return false;
        isJumping = false;
        return true;
    }

    public override WeaponBehaviour GetWeapon() => weapon;


    #endregion

    #region UNITY METHODS

    protected override void Awake()
    {
        input = new CharacterInput();
        input.Enable();
        input.Player.Jump.performed += OnJump;

        weapon = GetComponentInChildren<Weapon>();
    }

    protected override void Update()
    {
        movement = input.Player.Movement.ReadValue<Vector2>();
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

    private void OnJump(InputAction.CallbackContext context)
    {
        isJumping = true;
    }

    public override void SetData(Structs.CharacterData characterData)
    {
        throw new NotImplementedException();
    }

    public override void SetHealth(int healthToSet)
    {
        health = healthToSet;
    }

    public override void SetCoins(int coinsToSet)
    {
        coins = coinsToSet;
    }

    //public override void SetData(Structs.CharacterData characterData)
    //{
    //    health = characterData.health;
    //    coins = characterData.coins;
    //}

    #endregion
}
