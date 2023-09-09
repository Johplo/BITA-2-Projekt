using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.AI;


public class StandartEnemyAI : MonoBehaviour
{
    #region Johannes
    public Vector3 target;
    public GameObject player;

    public int damage = 1;

    private bool playerNearby = false;

    public NavMeshAgent agent;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        target = player.transform.position;

        float angle = Mathf.Atan2(player.transform.position.y - transform.position.y, player.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, agent.speed);

        if (!playerNearby) {
            SetPath();
        } else if (playerNearby)
        {
            SetPath();
            StartCoroutine(Attack());
        }
    }

    #region triggers/colliders
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }
    #endregion

    #region AILogic


    IEnumerator Attack()
    {
        //Play attack animation
        yield return new WaitForSecondsRealtime(3);
        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position, target);
        if (hit.transform.CompareTag("Player"))
        {
            hit.transform.GetComponent<Health>().TakeDamage(damage);
        }
    }

    private void SetPath()
    {
        agent.SetDestination(new Vector3(target.x, target.y, transform.position.z));
    }
    #endregion

    #endregion
}
