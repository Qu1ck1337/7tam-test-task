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
    private Joystick joystick;

    #endregion

    #region GETTERS



    #endregion

    #region UNITY METHODS

    protected override void Awake()
    {
        playerCharacter = GetComponent<CharacterBehaviour>();
        rigidbody = GetComponent<Rigidbody2D>();
        joystick = FindObjectOfType<Joystick>();
    }

    protected override void Start()
    {

    }

    protected override void FixedUpdate()
    {
        MoveAndRotate();
    }
    #endregion

    #region METHODS

    private void MoveAndRotate()
    {
        //Vector2 direction = playerCharacter.GetInputMovement();
        rigidbody.velocity = new Vector3(joystick.Direction.x, joystick.Direction.y, 0) * walkingSpeed;
        var direction = new Vector3(transform.position.x + joystick.Direction.x, transform.position.y + joystick.Direction.y, 0);
        if (joystick.Direction.magnitude == 0) return;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Mathf.Atan2(direction.y - transform.position.y, direction.x - transform.position.x) * Mathf.Rad2Deg - 90);
    }

    #endregion
}
