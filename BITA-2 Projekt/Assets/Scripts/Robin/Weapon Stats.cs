using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStats : MonoBehaviour
{

    #region Robin

    public float damage;
    public float speed;

    public void AddWeapon(float _damage, float _speed)
    {
        this.damage = _damage;
        this.speed = _speed;
    }

    #endregion
}
