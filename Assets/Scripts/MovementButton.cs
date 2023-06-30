using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementButton : MonoBehaviour
{
    #region METHODS

    public void ButtonClick(Enums.ButtonType buttonType)
    {
        OnButtonClicked.Invoke(buttonType);
    }

    #endregion

    #region EVENTS

    public event Action<Enums.ButtonType> OnButtonClicked;

    #endregion
}