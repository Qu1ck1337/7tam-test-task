using Photon.Pun;

public abstract class CharacterBehaviour : MonoBehaviourPun
{
    #region GETTERS

    public abstract int GetHealth();

    public abstract int GetMaxHealth();

    public abstract int GetCoins();

    public abstract WeaponBehaviour GetWeapon();

    #endregion

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
    /// Late Update.
    /// </summary>
    protected virtual void LateUpdate() { }

    #endregion

    #region METHODS

    public abstract void Damage(int damage);

    public abstract void SetHealth(int health);

    public abstract void SetCoins(int coins);

    #endregion
}