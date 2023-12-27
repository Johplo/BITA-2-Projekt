using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class MapVoting : NetworkBehaviour
{
    #region Johannes
    [SerializeField] private GameObject networkManager;
    [SerializeField] private string[] scenes;

    private int[] votings;
    private NetManager netmanager;

    public override void OnNetworkSpawn()
    {
        GetClientId();
        //Gets the NetManager from the NetworkManager gameobject.
        netmanager = networkManager.GetComponent<NetManager>();
        scenes = netmanager.GetScenes();
        votings = new int[scenes.Length];
    }

    void GetClientId(ServerRpcParams serverRpcParams = default)
    {
        ulong clientId = serverRpcParams.Receive.SenderClientId;
        GetMapVottingsServerRpc(clientId);
    }

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
}
