using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class PlayerKarmaPoint : MonoBehaviour
{
    public int karmaPoint;
    [SerializeField] Text karmaPointText;

    public void Start()
    {
        karmaPoint = 1000;
        karmaPointText = GameObject.Find("karmapointText").GetComponent<Text>();
    }

    public void GainKarmaPoint(int amount)
    {
        karmaPoint += amount;
    }
    public void LoseKarmaPoint(int amount)
    {
        karmaPoint -= amount;
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

