using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmeisenButtonscript : MonoBehaviour
{
    public GameObject[] doors;
    
    private void OnTriggerEnter2D(Collider2D other )
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Tür wechsel");

            foreach (GameObject s in doors)
            {
                if( s.activeSelf == true  )
                {
                    s.gameObject.SetActive( false );
                }
                else
                {
                    s.gameObject.SetActive( true );
                }
            }
        }
    }
}