using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStats : MonoBehaviour
{
    #region Robin
    public GameObject centerpos;

    public int ID;
    public float damage;
    public float speed;
    public float range;
    public float cooldown;

    private void Start()
    {
        if (centerpos == null)
        {
            centerpos = transform.Find("Center").gameObject;
        }
    }

    public void AddWeapon(int _ID, float _damage, float _speed, float _range, float _cooldown)
    {
        this.ID = _ID;
        this.damage = _damage;
        this.speed = _speed;
        this.range = _range;
        this.cooldown = _cooldown;
    }

    private void Update()
    {
        Vector3 Mousepos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        Vector3 direction = (Mousepos - transform.position);
        direction.Normalize();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, range);
            if(hit.collider != null)
            {
                Debug.LogWarning("doDamage");
            }
            Debug.DrawRay(transform.position, direction * range, Color.red);
        }
    }
    #endregion
}
