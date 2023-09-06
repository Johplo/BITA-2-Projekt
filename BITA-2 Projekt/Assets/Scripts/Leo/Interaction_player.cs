using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interaction_player : MonoBehaviour
{

    private bool ja;

    public GameObject dooractive;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ja = true;
            dooractive.SetActive(true);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) { 
            ja = false; 
            dooractive.SetActive(false);
        }
    }

    private void Update()
    {
        if (ja && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("labor");
        }
    }
}
