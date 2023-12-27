using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicNetworkingAIENemy : MonoBehaviour
{
    #region Johannes
    [SerializeField]
    private List<GameObject> player;

    public GameObject hitobject;
    public GameObject AttackEffect;

    public int damage = 1;
    public float range = 5f;
    public float cooldown = 2f;
    private int selectedPlayer;

    public bool playerNearby = false;
    public bool canattack = true;

    public NavMeshAgent agent;

    private void Start() {
        foreach (var item in GameObject.FindGameObjectsWithTag( "Player" )) {
            player.Add(item);
        }
    }

    public void Update()
    {
        if (playerNearby == true)
        {
            StartCoroutine(attackPlayer(selectedPlayer));
        } else
        {
            CheckforPlayer(selectedPlayer);
        }
    }

    private void CheckforPlayer(int t) {
        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.localPosition, (player[t].transform.position - transform.position), range);
        Debug.DrawRay(transform.localPosition, (player[t].transform.position - transform.position), Color.green);
        if (Physics2D.Raycast(transform.localPosition, (player[t].transform.position - transform.position), range) && hit.transform.tag == "Player") {
            hitobject = hit.transform.gameObject;
            playerNearby = true;
        }
        else {
            playerNearby = false;
        }
    }

    IEnumerator attackPlayer(int t)
    {
        AttackEffect.GetComponent<ParticleSystem>().Play();
        canattack = false;
        player[t].GetComponent<Health>().TakeDamage(damage);
        yield return new WaitForSecondsRealtime(cooldown);
        canattack = true;
    }

    void setPath(int t)
    {
        agent.SetDestination(new Vector3(player[t].transform.position.x, player[t].transform.position.y, this.transform.position.z));
    }
    #endregion
}
