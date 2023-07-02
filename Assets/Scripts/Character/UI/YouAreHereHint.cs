using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouAreHereHint : MonoBehaviour
{
    #region SERIALIZED FIELDS

    [SerializeField] private GameObject hintPrefab;
    [SerializeField] private float timeToDeleteHint;

    #endregion

    #region FIELDS

    private GameObject hintObj;

    #endregion

    #region UNITY METHODS

    private void Start()
    {
        if (GetComponent<PUN2_PlayerSync>().photonView.IsMine)
        {
            hintObj = Instantiate(hintPrefab, transform);
            StartCoroutine(Timer());
        }
    }

    private void Update()
    {
        if (hintObj != null)
        {
            hintObj.transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    #endregion

    #region COROUTINES

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(timeToDeleteHint);
        Destroy(hintObj);
    }

    #endregion
}
