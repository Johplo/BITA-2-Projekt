using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetworkButtons : MonoBehaviour
{
    #region Johannes
    public NetworkManager NetworkManager;

    public string IPAddress = "0.0.0.0";
    public int Port = 7777;

    public GameObject NametagHolder;

    public string myAddressGlobal;
    public string mylocalAddress;


    private void Awake()
    {
        if (NetworkManager == null)
        {
            Debug.LogError("Network Manager is not set!");
        }
    }

    private void Start()
    {
        FindGlobalIP();
        GetLocalIPAddress();
    }

    #region Publication
    public void SetName(string _name)
    {
        PlayerPrefs.SetString("Name", _name);
        GameObject.Find("Infos").GetComponent<ItemInfo>().SetName();
    }

    public void SetIPAddress(string _IP)
    {
        IPAddress = _IP;
    }

    public void SetPort(string _port)
    {
        Port = int.Parse(_port);
    }

    public void HostButton()
    {
        NetworkManager.Singleton.GetComponent<UnityTransport>().SetConnectionData("0.0.0.0", (ushort)Port);
        try
        {
            NetworkManager.Singleton.StartHost();
        } catch (Exception e)
        {
            Debug.LogException(e);
        }
    }

    public void JoinButton()
    {
        NetworkManager.Singleton.GetComponent<UnityTransport>().SetConnectionData(IPAddress, (ushort)Port);
        try
        {
            NetworkManager.Singleton.StartClient();
        } catch (Exception ex){
            Debug.LogException(ex);
        }
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void DisconnectButton()
    {
        NetworkManager.Singleton.Shutdown();
    }
    #region infos
    public string GetHostIP()
    {
        return myAddressGlobal;
    }

    public int GetHostPort()
    {
        return Port;
    }
    #endregion
    #endregion
    #region GetIPs
    private void FindGlobalIP()
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.ipify.org");
        request.Method = "GET";
        request.Timeout = 1000; //time in ms
        try
        {
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                myAddressGlobal = reader.ReadToEnd();
            } //if
            else
            {
                Debug.LogError("Timed out? " + response.StatusDescription);
                myAddressGlobal = "127.0.0.1";
            } //else
        } //try
        catch (WebException ex)
        {
            Debug.Log("Likely no internet connection: " + ex.Message);
            myAddressGlobal = "127.0.0.1";
        } //catch
        //myAddressGlobal=new System.Net.WebClient().DownloadString("https://api.ipify.org");
    }
    public void GetLocalIPAddress()
    {
        IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());
        foreach (IPAddress ip in hostEntry.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                mylocalAddress = ip.ToString();
                break;
            } //if
        } //foreach
    }
    #endregion
    #endregion
}
