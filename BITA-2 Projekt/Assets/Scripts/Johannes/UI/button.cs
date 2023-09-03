using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    /*
        Einfaches Script, um zu erkennen, was fuer ein objekt mit dem Knopf verbunden ist.
        Beispiel sind Waffen, Consumables etc.
        Waffen sollen dem SPieler Hinzugefuegt werden, Consumables dem Inventar.
    */
    #region Johannes
    private int ID;
    private int typeID;

    private Weapon weaponInfo;

    private void Awake()
    {
        weaponInfo = GameObject.Find("Info").GetComponent<ItemInfo>().FindObject(typeID, ID);
    }

    public void AddtoInventory()
    {
        if (typeID == 0)
        {
            //muck rueckwaerts
        }
    }

    #region PublicVariable
    public void SetIDs(int ID, int typeID) {
        this.ID = ID;
        this.typeID = typeID;
    }

    public int gettypeID() {
        return typeID;
    }
    public int getID() {
        return ID;
    }
    #endregion
    #endregion
}
