using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    #region SERIALIZED FIELDS

    [SerializeField] private Image fillArea;

    [Space]
    [Header("Color Settings")]
    [SerializeField] private Color maxColor = Color.green;
    [SerializeField] private Color minColor = Color.red;

    #endregion

    #region FIELDS

    private Slider healthBar;
    private CharacterBehaviour character;

    #endregion

    #region UNITY METHODS

    private void Awake()
    {
        character = GetComponentInParent<CharacterBehaviour>();
        healthBar = GetComponent<Slider>();
        healthBar.maxValue = character.GetMaxHealth();
        healthBar.value = character.GetHealth();
    }

    private void Update()
    { 
        healthBar.value = character.GetHealth();
        fillArea.color = Color.Lerp(minColor, maxColor, healthBar.value / healthBar.maxValue);
    }

    #endregion
}
