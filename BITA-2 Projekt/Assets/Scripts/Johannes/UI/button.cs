using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
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

    public string ItemName;

    private Weapon weaponInfo;

    private Healflask healflask;

    private GameObject Canvas;

    

    private void ItemInfoCreation()
    {
        Canvas = this.gameObject.transform.parent.transform.parent.gameObject;
        if (typeID == 0)
        {
            weaponInfo = GameObject.Find("Infos").GetComponent<ItemInfo>().FindWeapon(ID);
            healflask = null;
            ItemName = weaponInfo.Name;
        } else if (typeID == 1)
        {
            healflask = GameObject.Find("Infos").GetComponent<ItemInfo>().FindHealflask(ID);
            weaponInfo = null;
            ItemName = healflask.Name;
        }
    }

    #region ButtonAction
    public void AddtoInventory()
    {
        if (typeID == 0)
        {
            GameObject.Find("Player").GetComponent<WeaponStats>().AddWeapon(ID, weaponInfo.Damage, weaponInfo.Speed, weaponInfo.Range, weaponInfo.Cooldown);
            GameObject.Find("PickUpArea").GetComponent<InteractionManager>().RemoveItem(ItemName);
            Canvas.GetComponent<ItemManagementUI>().InventoryRemove(ItemName);
        } else if (typeID == 1)
        {
            GameObject.Find("Infos").GetComponent<ItemInfo>().AddHealflask(healflask.Healstrength);
            GameObject.Find("PickUpArea").GetComponent<InteractionManager>().RemoveItem(ItemName);
            Canvas.GetComponent<ItemManagementUI>().InventoryRemove(ItemName);
            Destroy(this.gameObject);
        }
    }
    #endregion
    #region PublicVariable
    public void SetIDs(int ID, int typeID) {
        this.ID = ID;
        this.typeID = typeID;
        ItemInfoCreation();
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
