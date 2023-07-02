using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    #region UNITY METHODS
    private void Start()
    {
        SceneManager.LoadSceneAsync("Lobby");
    }
    #endregion
}
