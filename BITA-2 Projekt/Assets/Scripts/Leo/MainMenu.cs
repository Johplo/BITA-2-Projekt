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

    public void Playclick()
    {
        audioManager.PlaySFX(audioManager.ClickSound);
    }

    #region leo 
    public void PlayGame()
    {
        StartCoroutine(Playclickplay());
    }

    public IEnumerator Playclickplay()
    {
        audioManager.PlaySFX(audioManager.ClickSound);
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene("Home");
    }

    public void QuitGame ()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    #endregion
}
