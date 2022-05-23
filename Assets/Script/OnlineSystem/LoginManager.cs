using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using System;
using System.Text;
using UnityEngine.UI;


public class LoginManager : MonoBehaviour
{
    public Text playerNameInputField;
    
    public GameObject loginPanel;
    public GameObject leaveButton;
    public GameObject mainCamera;
    public string ipAddress = "127.0.0.1";
    public Text joinCode;

  
    public async void Client()
    {
        if (RelayManager.Instance.IsRelayEnabled && !string.IsNullOrEmpty(joinCode.text))
        {
            await RelayManager.Instance.JoinRelay(joinCode.text);
            NetworkManager.Singleton.NetworkConfig.ConnectionData =
            Encoding.ASCII.GetBytes(playerNameInputField.text);
            NetworkManager.Singleton.StartClient();
        }
        
    }
    //public void OnIpAddressChange(string address)
    //{
    //    this.joinCode.ToString() = address;
    //}

    public async void Host()
    {
        if (RelayManager.Instance.IsRelayEnabled)
        {
            await RelayManager.Instance.SetupRelay();

        }
        NetworkManager.Singleton.ConnectionApprovalCallback += ApprovalCheck;
        NetworkManager.Singleton.StartHost();
    }

    private void Start()
    {
        NetworkManager.Singleton.OnServerStarted += HandleServerStarted;
        NetworkManager.Singleton.OnClientConnectedCallback += HandleClientConnected;
        NetworkManager.Singleton.OnClientDisconnectCallback += HandleClientDisconnect;
        SetUiVisibility(false);
    }

    private void SetUiVisibility(bool isUserLogin)
    {
        if (isUserLogin)
        {
            loginPanel.SetActive(false);
            mainCamera.SetActive(false);
            leaveButton.SetActive(true);
            
            
        }
        else
        {
            loginPanel.SetActive(true);
            mainCamera.SetActive(true);
            leaveButton.SetActive(false);
           

        }
    }

    private void OnDestroy()
    {
        if (NetworkManager.Singleton == null) { return; }
        NetworkManager.Singleton.OnServerStarted -= HandleServerStarted;
        NetworkManager.Singleton.OnClientConnectedCallback -= HandleClientConnected;
        NetworkManager.Singleton.OnClientDisconnectCallback -= HandleClientDisconnect;
    }

    private void HandleClientConnected(ulong clientId)
    {
        Debug.Log("client id = " + clientId);
        SetUiVisibility(true);
        if (clientId == NetworkManager.Singleton.LocalClientId)
        {
            SetUiVisibility(true);
        }
    }

    private void HandleClientDisconnect(ulong clientId)
    {
        if (clientId == NetworkManager.Singleton.LocalClientId)
        {
            
            SetUiVisibility(false);
        }
    }

    private void HandleServerStarted()
    {
        //throw new NotImplementedException();
    }

    public void Leave()
    {
        if (NetworkManager.Singleton.IsHost)
        {
            NetworkManager.Singleton.Shutdown();
            NetworkManager.Singleton.ConnectionApprovalCallback -= ApprovalCheck;
        }
        else if (NetworkManager.Singleton.IsClient)
        {
            NetworkManager.Singleton.Shutdown();
        }
    
        SetUiVisibility(false);
    }




    private void ApprovalCheck(byte[] connectionData, ulong clientId, NetworkManager.ConnectionApprovedDelegate callback)
    {
        string playerName = Encoding.ASCII.GetString(connectionData);
        bool approveConnection = playerName != playerNameInputField.text;
        Vector2 spawnPos = Vector2.zero;
        //Quaternion spawnRot = Quaternion.identity;

        Debug.Log("count = " + NetworkManager.Singleton.ConnectedClients.Count);
        // if it's server player
        if (clientId == NetworkManager.Singleton.LocalClientId)
        {
            SetUiVisibility(true);
            spawnPos = new Vector3(-2f, 2f);
            //spawnRot = Quaternion.Euler(0f, 135f, 0f);
        }
        else
        {
            switch (NetworkManager.Singleton.ConnectedClients.Count)
            {
                case 1:
                    spawnPos = new Vector3(0f, 1f);
                    //spawnRot = Quaternion.Euler(0f, 180f, 0f);
                    break;
                case 2:
                    spawnPos = new Vector3(2f, 1f);
                    //spawnRot = Quaternion.Euler(0f, 225f, 0f);
                    break;
            }
        }

        NetworkLog.LogInfoServer("SpawnPos of " + clientId + " is " + spawnPos.ToString());
        bool createPlayerObject = true;
        callback(createPlayerObject, null, approveConnection, spawnPos, null);

    }
}
