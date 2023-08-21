using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    #region Initialization
    public float movespeed;
    public Rigidbody2D rb;

    Vector2 moveing;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    #endregion
    void Update()
    {
        moveing.x = Input.GetAxisRaw("Horizontal");
        moveing.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        Move();
    }

    #region Movement
    void Move()
    {
        rb.MovePosition(moveing);
    }
    #endregion
}
