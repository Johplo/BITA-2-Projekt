using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponDisplay : MonoBehaviour
{
    #region Johannes
    public Weapon weapon;

    public Sprite ItemPreview;
    public string ItemName;
    public string ItemDescription;

    public int typeID;
    public int ID;

    private void Start()
    {

        ItemPreview = weapon.Picture;
        ItemName = weapon.Name;
        ItemDescription = weapon.Description;

        transform.name = ItemName;

        typeID = weapon.typeID;
        ID = weapon.ID;
    }
    #endregion
}
