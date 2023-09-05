using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interaction_player : MonoBehaviour
{


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("labor");

            //if (Input.GetKeyDown( KeyCode.E ))
            //{
            //    SceneManager.LoadScene("labor");
            //}
            
        }
    }
}
