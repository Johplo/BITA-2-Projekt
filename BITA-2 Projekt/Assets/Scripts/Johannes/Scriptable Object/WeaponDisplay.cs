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

    public float damage;
    public float speed;
    public float Range;
    public float cooldown;


    public int typeID = 0;
    public int ID;

    private void Start()
    {

        ItemPreview = weapon.Picture;
        ItemName = weapon.Name;
        ItemDescription = weapon.Description;

        damage = weapon.Damage;
        speed = weapon.Speed;
        Range = weapon.Range;
        cooldown = weapon.Cooldown;

        transform.name = ItemName;

        typeID = weapon.typeID;
        ID = weapon.ID;
    }
    #endregion
}
