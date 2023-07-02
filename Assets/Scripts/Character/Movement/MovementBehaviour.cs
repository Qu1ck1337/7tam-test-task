using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public abstract class MovementBehaviour : MonoBehaviour
{
    #region UNITY METHODS

    protected virtual void Awake() { }

    protected virtual void Start() { }

    protected virtual void Update() { }

    protected virtual void FixedUpdate() { }

    protected virtual void LateUpdate() { }

    #endregion

    #region METHODS

    public abstract void DisableJoystick();

    public abstract void EnableJoystick();

    #endregion
}
