using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerNameUI : MonoBehaviour
{
    #region Johannes
    public GameObject NameField;
    public string Name = "Player";

    private void Awake()
    {
        Name = GameObject.Find("Infos").GetComponent<ItemInfo>().PlayerName;
        NameField.GetComponent<TMP_Text>().text = Name;
    }
    #endregion
}
