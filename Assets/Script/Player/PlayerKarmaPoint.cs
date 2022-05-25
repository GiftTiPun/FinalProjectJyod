using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class PlayerKarmaPoint : NetworkBehaviour
{
    public int karmaPoint;
    [SerializeField] Text karmaPointText;
   
    
    
    

    public void Start()
    {
        karmaPoint = 1000;
        karmaPointText = GameObject.Find("karmapointText").GetComponent<Text>();
      
       
       
    }

    [ClientRpc]
    public void GainKarmaPointClientRpc(int amount)
    {
        karmaPoint += amount;
    }
    [ServerRpc]
    public void GainKarmaPointServerRpc(int amount)
    {
        GainKarmaPointClientRpc(amount);
    }
    [ClientRpc]
    public void LoseKarmaPointClientRpc(int amount)
    {
        karmaPoint -= amount;
    }
    [ServerRpc]
    public void LoseKarmaPointServerRpc(int amount)
    {
        LoseKarmaPointClientRpc(amount);
    }

    [ClientRpc]
    public void CheckPointClientRpc()
    {
        karmaPointText.text = karmaPoint.ToString();
    }
    [ServerRpc]
    public void CheckPointServerRpc()
    {
        CheckPointClientRpc();
    }
    public void Update()
    {
        if(gameObject.GetComponent<NetworkObject>().IsLocalPlayer)
        {
            CheckPointServerRpc();
        }
       
    }

    

}

