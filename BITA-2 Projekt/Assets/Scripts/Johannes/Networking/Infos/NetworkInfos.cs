using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class NetworkInfos : NetworkBehaviour
{
    #region Johannes
    private NetworkVariable<List<string>> playernames = new(writePerm: NetworkVariableWritePermission.Server);

    private NetworkVariable<string> HostAddress = new(writePerm: NetworkVariableWritePermission.Server);
    private NetworkVariable<int> HostPort = new(writePerm: NetworkVariableWritePermission.Server);

    [ServerRpc]
    public void SendPlayernameServerRPC(string _name)
    {
        playernames.Value.Add( _name );
        Debug.Log("Connected" + _name);
    }

    public override void OnNetworkSpawn()
    {
        if (IsHost || IsServer)
        {
            HostAddress.Value = GameObject.Find("Canvas").GetComponent<NetworkButtons>().GetHostIP();
            HostPort.Value = GameObject.Find("Canvas").GetComponent<NetworkButtons>().GetHostPort();
        }
    }
    #endregion
}
