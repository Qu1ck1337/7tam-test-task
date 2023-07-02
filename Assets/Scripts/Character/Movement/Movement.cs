using UnityEngine;

public class Movement : MovementBehaviour
{
    #region SERIALIZED FIELDS

    [SerializeField] private float walkingSpeed = 10f;

    #endregion

    #region FIELDS

    private CharacterBehaviour playerCharacter;
    private Rigidbody2D rigidBody;
    private Joystick joystick;

    #endregion

    #region GETTERS



    #endregion

    #region UNITY METHODS

    protected override void Awake()
    {
        playerCharacter = GetComponent<CharacterBehaviour>();
        rigidBody = GetComponent<Rigidbody2D>();
        joystick = FindObjectOfType<Joystick>();
    }

    protected override void Start()
    {

    }

    protected override void Update()
    {
        if (!GameManager.Self.GetIsGameStarted()) DisableJoystick();
        else EnableJoystick();
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
        rigidBody.velocity = new Vector3(joystick.Direction.x, joystick.Direction.y, 0) * walkingSpeed;
        var direction = new Vector3(transform.position.x + joystick.Direction.x, transform.position.y + joystick.Direction.y, 0);
        if (joystick.Direction.magnitude == 0) return;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Mathf.Atan2(direction.y - transform.position.y, direction.x - transform.position.x) * Mathf.Rad2Deg - 90);
    }

    public override void DisableJoystick()
    {
        joystick.gameObject.SetActive(false);
    }

    public override void EnableJoystick()
    {
        joystick.gameObject.SetActive(true);
    }

    #endregion
}
