using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicNetworkingAIENemy : MonoBehaviour
{
    #region Johannes
    //Initialiesierung von objekten (Spielerposition, ...).
    [SerializeField]
    private List<GameObject> player;

    public GameObject hitobject;
    public GameObject AttackEffect;

    public int damage = 1;
    public float range = 5f;
    public float cooldown = 2f;

    public bool playerNearby = false;
    public bool canattack = true;

    public NavMeshAgent agent;

    private void Start() {
        foreach (var item in GameObject.FindGameObjectsWithTag( "Player" )) {
            player.Add(item);
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
    #endregion
}
