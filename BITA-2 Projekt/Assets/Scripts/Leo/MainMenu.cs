using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MainMenu : MonoBehaviour   
{
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    #region leo 
    public void PlayGame()
    {
        audioManager.PlaySFX( audioManager.ClickSound );
    
        SceneManager.LoadScene("Home");
    }

    public void QuitGame ()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    #endregion
}
