using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Enums;

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
    private List<MovementButton> movementButtons = new List<MovementButton>();
    private float horizontalDirection = 0;

    #endregion

    #region GETTERS



    #endregion

    #region UNITY METHODS

    protected override void Awake()
    {
        playerCharacter = GetComponent<CharacterBehaviour>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    protected override void Start()
    {

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
        //Vector2 direction = playerCharacter.GetInputMovement();
        rigidbody.velocity = new Vector3(horizontalDirection * walkingSpeed, rigidbody.velocity.y, 0);
    }

    public void OnRightButtonDown()
    {
        horizontalDirection = 1f;
    }

    public void OnLeftButtonDown()
    {
        horizontalDirection = -1f;
    }

    public void OnMoveButtonUp()
    {
        horizontalDirection = 0;
    }

    private void Jump()
    {
        if (!playerCharacter.IsJumping() || !grounded) return;
        rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    #endregion
}
