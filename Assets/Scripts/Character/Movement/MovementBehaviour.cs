using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public abstract class MovementBehaviour : MonoBehaviour
{
    #region UNITY METHODS

    /// <summary>
    /// Awake.
    /// </summary>
    protected virtual void Awake() { }

    /// <summary>
    /// Start.
    /// </summary>
    protected virtual void Start() { }

    /// <summary>
    /// Update.
    /// </summary>
    protected virtual void Update() { }

    /// <summary>
    /// Update.
    /// </summary>
    protected virtual void FixedUpdate() { }

    /// <summary>
    /// Late Update.
    /// </summary>
    protected virtual void LateUpdate() { }

    #endregion

    #region METHODS

    public abstract void DisableJoystick();

    public abstract void EnableJoystick();

    #endregion
}
