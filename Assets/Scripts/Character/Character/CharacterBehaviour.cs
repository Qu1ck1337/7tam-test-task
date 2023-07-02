using Photon.Pun;

public abstract class CharacterBehaviour : MonoBehaviourPun
{
    #region GETTERS

    /// <summary>
    /// Health
    /// </summary>
    /// <returns>player's health</returns>
    public abstract int GetHealth();

    /// <summary>
    /// Player's max health
    /// </summary>
    /// <returns></returns>
    public abstract int GetMaxHealth();

    /// <summary>
    /// Coins
    /// </summary>
    /// <returns>player's coins</returns>
    public abstract int GetCoins();

    /// <summary>
    /// Returns playes's weapon
    /// </summary>
    /// <returns></returns>
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