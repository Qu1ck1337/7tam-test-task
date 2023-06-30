using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    #region SERIALIZED FIELDS

    [SerializeField] private Joystick joystick;

    #endregion

    #region FIELDS

    private CharacterBehaviour playerCharacter;

    #endregion

    #region UNITY METHODS

    private void Start()
    {
        playerCharacter = GetComponent<CharacterBehaviour>();
    }

    private void Update()
    {
        if (joystick.Direction.magnitude > 0)
        {
            var weapon = playerCharacter.GetWeapon();
            var slidePos = new Vector3(weapon.transform.position.x + joystick.Direction.x, weapon.transform.position.y + joystick.Direction.y, 0);
            weapon.transform.rotation = Quaternion.Euler(weapon.transform.rotation.eulerAngles.x, weapon.transform.rotation.eulerAngles.y, Mathf.Atan2(slidePos.y - weapon.transform.position.y, slidePos.x - weapon.transform.position.x) * Mathf.Rad2Deg - 90);
            weapon.Fire();
        }
    }

    #endregion
}
