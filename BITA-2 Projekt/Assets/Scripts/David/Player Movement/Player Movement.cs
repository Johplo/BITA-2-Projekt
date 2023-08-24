using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region DavidMovement
    public float moveSpeed;

    public Rigidbody2D rb;

    private Vector2 moveDirection;
    private Vector2 smoothedMovement;
    private Vector2 smoothVelocity;
    //Dash
    private float activeMoveSpeed;
    public float dashSpeed;

    public float dashLength = .5f, dashCooldown = 1f;

    [SerializeField]
    private float dashCounter;
    [SerializeField]
    private float dashCoolCounter;


    void Start()
    {
        activeMoveSpeed = moveSpeed;
    }
    void Update()
    {
        ProcessInputs();

        //Dash
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
            }
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0)
            {
                activeMoveSpeed = moveSpeed;
                dashCoolCounter = dashCooldown;
            }
        }

        if (dashCoolCounter >= 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        Move();
       
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY);
    }

    void Move() 
    {
        smoothedMovement = Vector2.SmoothDamp(smoothedMovement, moveDirection, ref smoothVelocity, 0.1f);
        rb.velocity = smoothedMovement * activeMoveSpeed;
    }
    #endregion
}
