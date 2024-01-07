using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerMovementNet : NetworkBehaviour
{
    #region Johannes
    public float moveSpeed;

    public Rigidbody2D rb;

    private Vector2 moveDirection;
    private Vector2 smoothedMovement;
    private Vector2 smoothVelocity;
    public float dashSpeed;

    private float activeMoveSpeed;
    public float dashLength = .5f, dashCooldown = 1f;

    private float dashCounter;
    private float dashCoolCounter;

    //Objekt, in dem alle Animationen gespeichert sind
    public Animator anim;

    public override void OnNetworkSpawn() {
        if (!IsOwner) Destroy(this);

        GameObject.Find("MapvotingPanel").GetComponent<MapVoting>().GetClientId();
    }

    void Start() {
        activeMoveSpeed = moveSpeed;
    }
    void Update() {
        ProcessInputs();

        //Dash
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (dashCoolCounter <= 0 && dashCounter <= 0) {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
            }
        }

        if (dashCounter > 0) {
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0) {
                activeMoveSpeed = moveSpeed;
                dashCoolCounter = dashCooldown;
            }
        }

        if (dashCoolCounter >= 0) {
            dashCoolCounter -= Time.deltaTime;
        }
    }

    private void FixedUpdate() {
        Move();
    }

    void ProcessInputs() {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY);

        moveDirection = Vector2.ClampMagnitude(moveDirection, 1);
        //Alle Variablen, die Gesetz werden muessen um animationmen zum Abspielen zu bringen
        //Setzt Speed auf die geschwindigkeit.
        anim.SetFloat("Speed", moveDirection.sqrMagnitude);
        //Setzt alle Axen im Animator auf die Axen vom Spieler
        anim.SetFloat("Horizontal", moveX);
        anim.SetFloat("Vertical", moveY);

        if (moveX >= 0.1f || moveY >= 0.1f || moveX <= -0.1f || moveY <= -0.1f) CheckDirection(moveX, moveY);
    }

    //Setzt die Richtung,damit der wchsel zu Idle passt
    void CheckDirection(float _moveX, float _moveY) {
        if (_moveX >= 0.9f && _moveY < 0.9f && _moveY > -0.9f) {
            anim.SetInteger("Dir", 1);
        }
        else if (_moveX <= -0.9f && _moveY < 0.9f && _moveY > -0.9f) {
            anim.SetInteger("Dir", 3);
        }
        else if (_moveY >= 0.9f && _moveX < 0.9f && _moveX > -0.9f) {
            anim.SetInteger("Dir", 0);
        }
        else if (_moveY <= -0.9f && _moveX < 0.9f && _moveX > -0.9f) {
            anim.SetInteger("Dir", 2);
        }
    }

    void Move() {
        smoothedMovement = Vector2.SmoothDamp(smoothedMovement, moveDirection, ref smoothVelocity, 0.1f);
        rb.velocity = smoothedMovement * activeMoveSpeed;
    }
    #endregion
}
