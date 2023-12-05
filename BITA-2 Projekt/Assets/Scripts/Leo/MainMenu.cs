using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    #region leo 
    public void PlayGame()
    {
        SceneManager.LoadScene("Home");
    }

    public void QuitGame ()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    #endregion
}
