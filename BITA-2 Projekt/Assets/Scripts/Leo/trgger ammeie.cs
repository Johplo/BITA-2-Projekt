using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class trggerammeie : MonoBehaviour
{
    public GameObject UiObject;
    


    // Start is called before the first frame update
    void Start()
    {
        UiObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            UiObject.SetActive(true);
            Debug.Log("triggerd");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        StartCoroutine(Showtextlonger());
    }

    private IEnumerator Showtextlonger()
    {
        yield return new WaitForSecondsRealtime(2);
        UiObject.SetActive(false);
        
    }
}
