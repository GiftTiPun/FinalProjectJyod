using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using System;
using System.Text;
using UnityEngine.UI;
using Unity.Netcode.Transports.UNET;

public class PlayerClass : MonoBehaviour
{
    public Text playerNameInputField;
    public GameObject loginPanel;
    public GameObject leaveButton;
    public string ipAddress = "127.0.0.1";

    public string joinCode;

    public void OnIpAddressChange(string address)
    {
        this.joinCode = address;
    }

    public async void Client()
    {
        //transport = NetworkManager.Singleton.GetComponent<UNetTransport>();
        //transport.ConnectAddress = ipAddress;
        if (RelayManager.Instance.IsRelayEnabled && !string.IsNullOrEmpty(joinCode))
        {
            await RelayManager.Instance.JoinRelay(joinCode);
        }
        NetworkManager.Singleton.NetworkConfig.ConnectionData =
        Encoding.ASCII.GetBytes(playerNameInputField.text);
        NetworkManager.Singleton.StartClient();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
