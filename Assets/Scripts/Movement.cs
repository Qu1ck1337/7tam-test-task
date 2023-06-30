using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MovementBehaviour
{
    #region SERIALIZED FIELDS

    [SerializeField] private float walkingSpeed = 10f;
    [SerializeField] private float jumpForce = 100f;

    #endregion

    #region FIELDS

    private CharacterBehaviour playerCharacter;
    private Rigidbody2D rigidbody;
    private bool grounded;

    #endregion

    #region GETTERS



    #endregion

    #region UNITY METHODS

    protected override void Awake()
    {
        playerCharacter = GetComponent<CharacterBehaviour>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    protected override void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        } 
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }
    #endregion

    #region METHODS

    private void Move()
    {
        Vector2 direction = playerCharacter.GetInputMovement();
        rigidbody.velocity = new Vector3(direction.x * walkingSpeed, rigidbody.velocity.y, 0);
    }

    private void Jump()
    {
        if (!playerCharacter.IsJumping() || !grounded) return;
        rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    #endregion
}
