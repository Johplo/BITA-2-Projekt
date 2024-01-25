using Unity.Services.Lobbies.Models;
using UnityEngine;
using UnityEngine.AI;

public class PatrolEnemyAI : MonoBehaviour
{
    #region Johannes
    [Header("GameObjects")]
    [SerializeField] private GameObject[] pathjoints;
    [SerializeField] private GameObject target;

    public NavMeshAgent agent;

    private int pathindex;
    private bool Playernearby;

    private void Awake() {
        if (agent == null) { agent = GetComponent<NavMeshAgent>(); }
        if (target == null) { target = GameObject.Find("Player"); }
    }

    private void Start() {
        SetPath(pathindex, true);
    }

    private void Update() {
        if (!Playernearby) {
            SetPath(pathindex);
        }
        else {
            agent.SetDestination(new Vector3(target.transform.position.x, target.transform.position.y - 0.75f, target.transform.position.z));
        }
    }

    void SetPath(int index, bool forcepath = false) {
        if (!forcepath && transform.position == pathjoints[index].transform.position) {
            agent.SetDestination(pathjoints[index].transform.position);
            pathindex = index + 1;
        }
        else if (forcepath) {
            agent.SetDestination(pathjoints[index].transform.position);
        }
    }

    public void FoundPlayer() {
        Playernearby = true;
    }
    #endregion
}
