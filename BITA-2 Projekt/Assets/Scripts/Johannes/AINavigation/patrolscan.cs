using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrolscan : MonoBehaviour
{
    #region Johannes
    private PatrolEnemyAI ai;

    private void Awake() {
        ai = transform.parent.GetComponent<PatrolEnemyAI>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.transform.CompareTag("Player")) {
            ai.FoundPlayer();
        }
    }
    #endregion
}
