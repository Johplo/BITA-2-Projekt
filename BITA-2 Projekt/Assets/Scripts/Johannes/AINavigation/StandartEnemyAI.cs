using System.Collections;
using UnityEngine;
using UnityEngine.AI;


public class StandartEnemyAI : MonoBehaviour
{
    #region Johannes
    public Vector3 target;
    public GameObject player;

    public GameObject hitobject;
    public GameObject AttackEffect;


    public int damage = 1;
    public float range = 5f;
    public float cooldown = 2f;


    public bool playerNearby = false;
    public bool canattack = true;

    public NavMeshAgent agent;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        target = new Vector3(player.transform.position.x, player.transform.position.y - 0.75f, player.transform.position.z);

        float angle = Mathf.Atan2(player.transform.position.y - 0.75f - transform.position.y, player.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, agent.speed);

        CheckforPlayer();

        if (!playerNearby) {
            SetPath();
        } else if (playerNearby && canattack)
        {
            SetPath();
            StartCoroutine(Attack());
        }
    }

    #region check for player
    void CheckforPlayer() {
        RaycastHit2D hit;
        hit = Physics2D.Raycast(new Vector3(transform.localPosition.y, transform.localPosition.y, 0f), (target - transform.position), range);
        Debug.DrawRay(transform.localPosition, (target - transform.position) , Color.green);
        if (Physics2D.Raycast(new Vector3(transform.localPosition.y, transform.localPosition.y, 0f), (target - transform.position), range) && hit.transform.CompareTag("Player")) {
            Debug.LogWarning("Player was hit!!!!!");
            hitobject = hit.transform.gameObject;
            playerNearby = true;
        }
        else
        {
            playerNearby = false;
        }
    }
    #endregion

    #region AILogic


    IEnumerator Attack()
    {
        AttackEffect.GetComponent<ParticleSystem>().Play();
        canattack = false;
        hitobject.GetComponent<Health>().TakeDamage(damage);
        yield return new WaitForSecondsRealtime(cooldown);
        canattack = true;
    }

    private void SetPath()
    {
        agent.SetDestination(new Vector3(target.x, target.y, this.transform.position.z));
    }
    #endregion

    #endregion
}
