using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using Unity.Netcode;
using UnityEngine;

public class ItemInfo: MonoBehaviour
{
    //Script zum Managen aller Items im Spiel.
    //Items werden in IDs fuer jeden typ aufgeteilt und in dieser ID einer Eigenen zugewiesen.
    #region Johannes
    public List<Weapon> weaponList;
    public List<Healflask> healflasksList;

    public int healflasks;
    public string PlayerName = "Player";

    private void Start()
    {
        if (GameObject.Find("Infos"))
        {
            Destroy(this.gameObject);
        }
    }
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    #region PublicVariables
    public Weapon FindWeapon(int _ID)
    {
        return weaponList[_ID];
    }

    public void SetName()
    {
        PlayerName = PlayerPrefs.GetString("Name");
    }
    #region Healing
    public Healflask FindHealflask(int _ID)
    {
        return healflasksList[_ID];
    }

    public void AddHealflask(int _amount)
    {
        healflasks += _amount;
    }

    public int getHealamount()
    {
        return healflasks;
    }

    public void UpdateHealth() {
        healflasks -= 1;
    }
    #endregion
    #endregion
    #endregion
}
