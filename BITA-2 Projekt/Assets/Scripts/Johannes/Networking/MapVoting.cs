using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class MapVoting : NetworkBehaviour
{
    #region Johannes
    [SerializeField] private GameObject networkManager;
    [SerializeField] private List<string> scenes;

    private int[] votings;
    private NetManager netmanager;

    private bool didvote;
    private int votedindex;

    private void Awake()
    {
        if (networkManager == null)
        {
            networkManager = GameObject.Find("NetworkManager");
        }
        netmanager = networkManager.GetComponent<NetManager>();
    }

    public void GetClientId(ServerRpcParams serverRpcParams = default)
    {
        ulong clientId = serverRpcParams.Receive.SenderClientId;
        GetMapVottingsServerRpc(clientId);
    }

    public void AddMaplocal(string name)
    {
        int index = scenes.IndexOf(name);
        AddVotingtoMapClientRpc(index, didvote, votedindex);
        votedindex = index;
    }

    #region JoinRPCs
    [ServerRpc]
    public void GetMapVottingsServerRpc(ulong clientId)
    {
        ClientRpcParams clientRpcParams = new()
        {
            Send = new ClientRpcSendParams
            {
                TargetClientIds = new ulong[] { clientId }
            }
        };
        for (int i = 0; i < votings.Length; i++)
        {
            ReturnMapVotingsClientRpc(i, votings[i], clientRpcParams);
        }
    }

    /// <summary>
    /// Returns the voted maps when a new client connects
    /// </summary>
    /// <param name="_votings">equal to the active votes.</param>
    /// <param name="_scenes">equal to the scenelist.</param>
    [ClientRpc]
    private void ReturnMapVotingsClientRpc(int t, int voting, ClientRpcParams clientRpcParams = default)
    {
        if (IsOwner)
        {
            votings[t] = voting;
        }
    }
    #endregion
    #region Mapvoting
    /// <summary>
    /// Adds one voting to the selected map.
    /// </summary>
    /// <param name="mapname"></param>
    /// <param name="hasvoted"></param>
    /// <param name="previousIndex"></param>
    [ClientRpc]
    private void AddVotingtoMapClientRpc(int mapindex, bool hasvoted,  int previousIndex)
    {
        if (hasvoted)
        {
            votings[previousIndex] -= 1;
        }

        votings[mapindex] += 1;
    }
    #endregion
    #region get/set
    public string GetMostVotedName()
    {
        int index = 0;
        for (int i = 1; i < votings.Length; i++)
        {
            if (votings[i] > votings[i - 1])
            {
                index = i;
            }
        }
        return scenes[index];
    }
    #endregion
    #endregion
}
