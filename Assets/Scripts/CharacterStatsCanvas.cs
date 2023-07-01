using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterStatsCanvas : MonoBehaviour
{
    #region FIELDS

    private CharacterBehaviour character;
    private Vector3 originalLocalPosition;

    #endregion

    #region UNITY METHODS

    private void Awake()
    {
        character = GetComponentInParent<CharacterBehaviour>();
        originalLocalPosition = transform.localPosition;
    }

    private void Update()
    {
        Vector3 characterPos = character.transform.position;
        transform.position = new Vector3(characterPos.x + originalLocalPosition.x, characterPos.y + originalLocalPosition.y, characterPos.z + originalLocalPosition.z);
        transform.eulerAngles = new Vector3(0, 0, 0);
    }

    #endregion
}
