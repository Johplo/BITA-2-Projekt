using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class movement : MonoBehaviour
{
    #region Initialization
    public float movespeed;
    public Rigidbody2D rb;

    public GameObject nearbyobject;

    public KeyCode assigned;

    Vector2 moveing;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    #endregion

    #region Updates
    void Update()
    {
        moveing.x = Input.GetAxisRaw("Horizontal");
        moveing.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        Move();
    }
    #endregion

    #region Movement
    void Move()
    {
        rb.MovePosition(rb.position + moveing * movespeed * Time.fixedDeltaTime);
    }
    #endregion
}
