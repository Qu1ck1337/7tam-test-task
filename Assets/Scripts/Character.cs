using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Character : CharacterBehaviour
{
    #region SERIALIZED FIELDS

    [Header("Player Stats")]
    [SerializeField] private int health = 5;
    [SerializeField] private int coins = 0;

    #endregion

    #region FIELDS

    private CharacterInput input;
    private Vector2 movement;
    private bool isJumping;

    #endregion

    #region GETTERS

    public override int GetHealth() => health;

    public override int GetCoins() => coins;

    public override Vector2 GetInputMovement() => movement;

    public override bool IsJumping()
    {
        if (isJumping == false) return false;
        isJumping = false;
        return true;
    }


    #endregion

    #region UNITY METHODS

    protected override void Awake()
    {
        input = new CharacterInput();
        input.Enable();
        input.Player.Jump.performed += OnJump;
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

    private void OnJump(InputAction.CallbackContext context)
    {
        isJumping = true;
    }

    #endregion
}
