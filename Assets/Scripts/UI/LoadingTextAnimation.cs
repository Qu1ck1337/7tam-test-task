using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadingTextAnimation : MonoBehaviour
{
    #region SERIALIZED FIELDS

    [SerializeField] private float timeBetweenOptions = 0.5f;
    [SerializeField] private List<string> textOptions = new List<string>();

    #endregion

    #region FIELDS

    private int optionIndex = 0;
    private float timer;
    private TextMeshProUGUI label;

    #endregion

    #region UNITY METHODS

    private void Awake()
    {
        label = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (timer > timeBetweenOptions)
        {
            timer = 0;
            optionIndex += 1;
            if (optionIndex >= textOptions.Count) optionIndex = 0;
            label.text = textOptions[optionIndex].ToString();
        }
        timer += Time.deltaTime;
    }

    #endregion
}
