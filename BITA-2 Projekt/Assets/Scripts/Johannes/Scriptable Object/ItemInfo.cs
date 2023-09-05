using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    //Script zum Managen aller Items im Spiel.
    //IItems werden in IDs fuer jeden typ aufgeteilt und in dieser ID einer Eigenen zugewiesen.
    #region Johannes
    public List<Weapon> weaponList;
    public List<Healflask> healflasksList;


    public int healflasks;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    #region PublicVariables
    public Weapon FindWeapon(int _ID)
    {
        return weaponList[_ID];
    }

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
    #endregion
    #endregion
}
