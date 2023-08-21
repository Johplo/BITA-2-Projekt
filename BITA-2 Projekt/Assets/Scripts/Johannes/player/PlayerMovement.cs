using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
#region Initialization
    public float movespeed;
    public Rigidbody2D rb;

    Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
#endregion
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate() {
        Move();
    }

#region Movement
    void Move() {
        rb.MovePosition(movement);
    }
#endregion
}
