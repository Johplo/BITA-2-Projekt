using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class StartNetGame : NetworkBehaviour
{
    #region Johannes
    [SerializeField] private GameObject mapvotings;
    [SerializeField] private GameObject networkManager;

    private NetworkManager manager;
    private MapVoting voting;

    private void Start()
    {
        if (mapvotings == null)
        {
            mapvotings = GameObject.Find("MapvotingPanel");
        }
        voting = mapvotings.GetComponent<MapVoting>();
    }

    public void LoadVotedMap()
    {
        manager.SceneManager.LoadScene(voting.GetMostVotedName(), UnityEngine.SceneManagement.LoadSceneMode.Single);
    }
    #endregion
}
